using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoObsSistema
    {
        public int CoObs { get; set; }
        public string Descricao { get; set; }
        public long? CoSistema { get; set; }
        public string CoUsuario { get; set; }
        public DateTime? DtObs { get; set; }
    }
}
