using AgenceIntro.Domain.Dto;
using AgenceIntro.Domain.Services.Consultants.Dto;

namespace AgenceIntro.Domain.Services.Consultants
{
    public interface IConsultantDomainService
    {
        CollectionResponse<ConsultantDto> GetAll(PaginationResult input);

        CollectionResponse<IncomingDto> GetConsultansIncoming(IncomingInputDto input);
    }
}
