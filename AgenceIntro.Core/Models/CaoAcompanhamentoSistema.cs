using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoAcompanhamentoSistema
    {
        public int CoAcompanhamento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public long? CoSistema { get; set; }
        public string Status { get; set; }
    }
}
