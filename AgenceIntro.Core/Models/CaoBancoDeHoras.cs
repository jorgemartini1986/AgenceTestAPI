using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoBancoDeHoras
    {
        public int Id { get; set; }
        public string CoUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Segundos { get; set; }
        public string Tipo { get; set; }
    }
}
