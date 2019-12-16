using System.ComponentModel.DataAnnotations;

namespace AgenceIntro.Domain.Services.Consultants.Dto
{
    public class ConsultantBaseDto
    {
        [Required]
        public string CoUsuario { get; set; }
    }
}
