using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoConhecimentosFontes
    {
        public int Idfonte { get; set; }
        public int Idconhecimento { get; set; }
        public DateTime Datahora { get; set; }
        public string Arquivo { get; set; }
        public string Caminho { get; set; }

        public virtual CaoConhecimentos IdconhecimentoNavigation { get; set; }
    }
}
