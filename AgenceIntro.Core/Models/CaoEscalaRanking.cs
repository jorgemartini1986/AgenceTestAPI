using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoEscalaRanking
    {
        public CaoEscalaRanking()
        {
            CaoPontosConhecimento = new HashSet<CaoPontosConhecimento>();
        }

        public byte Idescala { get; set; }
        public byte QtdVisual { get; set; }
        public int Pontuacao { get; set; }

        public virtual ICollection<CaoPontosConhecimento> CaoPontosConhecimento { get; set; }
    }
}
