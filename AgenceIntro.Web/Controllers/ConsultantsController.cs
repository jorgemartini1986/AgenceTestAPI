using AgenceIntro.Domain.Dto;
using AgenceIntro.Domain.Services.Consultants;
using AgenceIntro.Domain.Services.Consultants.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AgenceIntro.Web.Controllers
{
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantDomainService consultantService;

        public ConsultantsController(IConsultantDomainService service)
        {
            consultantService = service;
        }

        [HttpGet]
        [Route("api/[controller]/list")]
        public ActionResult<CollectionResponse<ConsultantDto>> List(int page = 1, string sortBy = null)
        {
            const int MaxCount = 200;
            var skipCount = (page - 1) * MaxCount;
            return consultantService.GetAll(new PaginationResult(skipCount, MaxCount, sortBy));
        }

        [HttpPost]
        [Route("api/[controller]/incoming")]
        public ActionResult<CollectionResponse<IncomingDto>> GetConsultansIncoming(IncomingInputDto input)
        {
            return consultantService.GetConsultansIncoming(input);
        }
    }
}
