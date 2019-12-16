﻿using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoCategoriasOmbudsman
    {
        public CaoCategoriasOmbudsman()
        {
            CaoOmbudsman = new HashSet<CaoOmbudsman>();
        }

        public byte Idcategoria { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<CaoOmbudsman> CaoOmbudsman { get; set; }
    }
}
