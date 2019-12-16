using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoOsPrazo
    {
        public int CoPrazo { get; set; }
        public int? CoOs { get; set; }
        public int? CoFase { get; set; }
        public int? TotalAnalista { get; set; }
        public int? TotalHora { get; set; }
    }
}
