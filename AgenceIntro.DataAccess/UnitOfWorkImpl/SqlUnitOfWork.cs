using AgenceIntro.Core.Models;
using AgenceIntro.DataAccess.Contracts;
using AgenceIntro.DataAccess.RepositoryImpl;
using AgenceIntro.EntityFramework.Context;

namespace AgenceIntro.DataAccess.UnitOfWorkImpl
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly AgenceDbContext context;
        private IUserRepository userRepository;
        private IRepository<PermissaoSistema> systemPermissionRepository;
        private IRepository<CaoFatura> billRepository;
        private IRepository<CaoSalario> salaryRepository;
        private IRepository<CaoOs> serviceOrderRepository;

        public SqlUnitOfWork(AgenceDbContext agenceDbContext)
        {
            context = agenceDbContext;
        }

        public IUserRepository UserRepository =>
            this.userRepository ?? (this.userRepository = new UserRepository(this.context));

        public IRepository<PermissaoSistema> SystemPermissionRepository =>
            this.systemPermissionRepository ?? (this.systemPermissionRepository = new SqlRepository<PermissaoSistema>(this.context));

        public IRepository<CaoFatura> BillRepository =>
            this.billRepository ?? (this.billRepository = new SqlRepository<CaoFatura>(this.context));

        public IRepository<CaoSalario> SalaryRepository =>
            this.salaryRepository ?? (this.salaryRepository = new SqlRepository<CaoSalario>(this.context));

        public IRepository<CaoOs> ServiceOrderRepository =>
            this.serviceOrderRepository ?? (this.serviceOrderRepository = new SqlRepository<CaoOs>(this.context));

        public void SaveChages()
        {
            context.SaveChanges();
        }
    }
}
