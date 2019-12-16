using System;

namespace AgenceIntro.Domain.Services.Consultants.Dto
{
    public class IncomingByDate
    {
        public DateTime ReferenceDate { get; set; }

        public float NetEarnings { get; set; }

        public float FixedCost { get; set; }

        public float Commission { get; set; }

        public float Benefit { get; set; }
    }
}
