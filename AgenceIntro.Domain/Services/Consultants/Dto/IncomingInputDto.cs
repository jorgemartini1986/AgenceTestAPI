using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenceIntro.Domain.Services.Consultants.Dto
{
    public class IncomingInputDto
    {
        public List<ConsultantBaseDto> Consultants { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

    }
}
