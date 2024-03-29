﻿using System;
using System.Collections.Generic;

namespace AgenceIntro.Core.Models
{
    public partial class CaoOs
    {
        public CaoOs()
        {
            CaoHistOcorrenciasOs = new HashSet<CaoHistOcorrenciasOs>();
        }

        public int CoOs { get; set; }
        public int? NuOs { get; set; }
        public int? CoSistema { get; set; }
        public string CoUsuario { get; set; }
        public int? CoArquitetura { get; set; }
        public string DsOs { get; set; }
        public string DsCaracteristica { get; set; }
        public string DsRequisito { get; set; }
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFim { get; set; }
        public int? CoStatus { get; set; }
        public string DiretoriaSol { get; set; }
        public DateTime? DtSol { get; set; }
        public string NuTelSol { get; set; }
        public string DddTelSol { get; set; }
        public string NuTelSol2 { get; set; }
        public string DddTelSol2 { get; set; }
        public string UsuarioSol { get; set; }
        public DateTime? DtImp { get; set; }
        public DateTime? DtGarantia { get; set; }
        public int? CoEmail { get; set; }
        public int? CoOsProspectRel { get; set; }

        public virtual ICollection<CaoHistOcorrenciasOs> CaoHistOcorrenciasOs { get; set; }
    }
}
