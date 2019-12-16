using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoMovimentoJustificativa
    {
        public long CoMovimentoJustificativa { get; set; }
        public long CoMovimento { get; set; }
        public long NuOs { get; set; }
        public string DsJustificativa { get; set; }
    }
}
