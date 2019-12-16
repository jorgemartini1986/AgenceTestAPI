using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoPagamento
    {
        public long CoPagamento { get; set; }
        public string CoUsuario { get; set; }
        public string TpPagamento { get; set; }
        public DateTime DtPagamento { get; set; }
        public float VlPagamento { get; set; }
        public DateTime DtReferenciaPagamento { get; set; }
    }
}
