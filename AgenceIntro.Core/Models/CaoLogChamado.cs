﻿using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoLogChamado
    {
        public int Id { get; set; }
        public int CoChamado { get; set; }
        public DateTime DtChamado { get; set; }
        public string CoUsuario { get; set; }
        public int CoDaily { get; set; }
    }
}
