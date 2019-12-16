using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoTipoOmbudsman
    {
        public CaoTipoOmbudsman()
        {
            CaoOmbudsman = new HashSet<CaoOmbudsman>();
        }

        public byte Idtipo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<CaoOmbudsman> CaoOmbudsman { get; set; }
    }
}
