﻿using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoSalario
    {
        public string CoUsuario { get; set; }
        public DateTime DtAlteracao { get; set; }
        public float BrutSalario { get; set; }
        public float LiqSalario { get; set; }
    }
}
