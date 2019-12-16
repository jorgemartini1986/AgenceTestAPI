using System;
using System.Collections.Generic;
using System.Linq;
using AgenceIntro.Core.Models;
using AgenceIntro.DataAccess.Contracts;
using AgenceIntro.Domain.Dto;
using AgenceIntro.Domain.Services.Consultants.Dto;
using AutoMapper;

namespace AgenceIntro.Domain.Services.Consultants
{
    public class ConsultantDomainService : IConsultantDomainService
    {
        private readonly IUserRepository userRepository;
        private readonly IRepository<PermissaoSistema> systemPermissionRepository;
        private readonly IRepository<CaoFatura> billRepository;
        private readonly IRepository<CaoSalario> salaryRepository;
        private readonly IRepository<CaoOs> serviceOrderRepository;
        private readonly IMapper mapper;

        public ConsultantDomainService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.userRepository = unitOfWork.UserRepository;
            this.systemPermissionRepository = unitOfWork.SystemPermissionRepository;
            this.billRepository = unitOfWork.BillRepository;
            this.salaryRepository = unitOfWork.SalaryRepository;
            this.serviceOrderRepository = unitOfWork.ServiceOrderRepository;
            this.mapper = mapper;
        }

        public CollectionResponse<ConsultantDto> GetAll(PaginationResult input)
        {
            if (input.SkipCount < 0)
            {
                input.SkipCount = 0;
            }

            if (input.MaxCount < 0)
            {
                input.MaxCount = 0;
            }

            if (string.IsNullOrEmpty(input.SortBy))
            {
                input.SortBy = "NoUsuario";
            }

            // Apply business logic
            IQueryable<CaoUsuario> entities = GetFiteredResult();
            
            var propertyInfo = typeof(CaoUsuario).GetProperty(input.SortBy);
            List<CaoUsuario> result = entities.AsEnumerable().OrderBy(t => propertyInfo.GetValue(t, null)).Skip(input.SkipCount).Take(input.MaxCount).ToList();
            var response = new CollectionResponse<ConsultantDto> { SourceTotal = entities.Count() };
            response.Items.AddRange(mapper.Map<List<CaoUsuario>, List<ConsultantDto>>(result));

            return response;
        }

        public CollectionResponse<IncomingDto> GetConsultansIncoming(IncomingInputDto input)
        {
            if(input.Start > input.End)
            {
                throw new Exception("Invalid date range");
            }

            CollectionResponse<IncomingDto> result = new CollectionResponse<IncomingDto>();

            foreach (var consultant in input.Consultants)
            {
                var userName = consultant.CoUsuario;
                var userExist = userRepository.Get(userName) != null;
                if (!userExist)
                {
                    continue;
                }

                IncomingDto incomingDto = new IncomingDto();
                incomingDto.CoUsuario = userName;
                incomingDto.NoUsuario = ResolveUserFullname(userName);
                var incomings = this.ResolveIncomingByDate(userName, input.Start, input.End);
                incomings.ForEach(item => incomingDto.IncomingList.Add(item));
                result.Items.Add(incomingDto);
            }

            result.SourceTotal = result.Items.Count;

            CalculateIndividualEarningPercents(result);

            return result;
        }

        private static void CalculateIndividualEarningPercents(CollectionResponse<IncomingDto> result)
        {
            float totalOverAll = 0;
            result.Items.ForEach(incoming => totalOverAll += incoming.TotalPersonalEarnings);
            foreach (var item in result.Items)
            {
                item.EarningPercent = 100 * item.TotalPersonalEarnings / totalOverAll;
            }
        }

        private List<IncomingByDate> ResolveIncomingByDate(string coUsuario, DateTime start, DateTime end)
        {
            List<IncomingByDate> incomingByDate = new List<IncomingByDate>();
            
            var salary = salaryRepository.Find(s => s.CoUsuario == coUsuario).FirstOrDefault()?.BrutSalario ?? 0;

            IQueryable<CaoOs> orders = this.serviceOrderRepository.GetAll();
            IQueryable<CaoFatura> bills = this.billRepository.GetAll();

            IQueryable<CaoFatura> consultantBills = (from order in orders
                                                    join bill in bills
                                                    on order.CoOs equals bill.CoOs
                                                    where order.CoUsuario == coUsuario &&
                                                    bill.DataEmissao >= start &&
                                                    bill.DataEmissao <= end
                                                    select bill).OrderBy(i => i.DataEmissao);

            foreach (var item in consultantBills)
            {
                IncomingByDate incoming = new IncomingByDate();
                incoming.NetEarnings = item.Valor - (item.Valor * (item.TotalImpInc / 100));
                incoming.FixedCost = salary;
                incoming.Commission = incoming.NetEarnings * (item.ComissaoCn / 100);
                incoming.Benefit = incoming.NetEarnings - (incoming.FixedCost + incoming.Commission);

                incoming.ReferenceDate = item.DataEmissao;
                incomingByDate.Add(incoming);
            }

            List<IncomingByDate> incomingMergedByMonth = new List<IncomingByDate>();
            foreach (var item in incomingByDate)
            {
                var found = incomingMergedByMonth.FirstOrDefault(element => element.ReferenceDate.Month == item.ReferenceDate.Month &&
                element.ReferenceDate.Year == item.ReferenceDate.Year);
                if (found == null)
                {
                    incomingMergedByMonth.Add(item);
                }
                else
                {
                    found.NetEarnings += item.NetEarnings;
                    found.Commission += item.Commission;
                    found.Benefit = found.NetEarnings - (found.FixedCost + found.Commission);
                }
            }

            return incomingMergedByMonth;
        }

        private string ResolveUserFullname(string coUsuario)
        {
            return userRepository.Get(coUsuario)?.NoUsuario;
        }

        /// Conditions for PERMISSAO_SISTEMA -----------
        /// CO_SISTEMA = 1
        /// IN_ATIVO = S
        /// CO_TIPO_USUARIO = 0,1, 2
        private IQueryable<CaoUsuario> GetFiteredResult()
        {
            var users = userRepository.GetAll();
            var permissions = systemPermissionRepository.GetAll();

            var result = from user in users
                          join permission in permissions
                          on user.CoUsuario equals permission.CoUsuario
                          where permission.CoSistema == 1 &&
                          permission.InAtivo == "S" &&
                          (permission.CoTipoUsuario == 0 || permission.CoTipoUsuario == 1 || permission.CoTipoUsuario == 2)
                          select user;

            return result;
        }
    }
}
