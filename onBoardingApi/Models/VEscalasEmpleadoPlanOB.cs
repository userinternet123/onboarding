//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace onBoardingApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VEscalasEmpleadoPlanOB
    {
        public int IdColaborador { get; set; }
        public string NombreColaborador { get; set; }
        public Nullable<long> DPIColaborador { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; }
        public int IdArea { get; set; }
        public string NombreArea { get; set; }
        public Nullable<System.DateTime> FechaEvaluacion { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<bool> Realizado { get; set; }
        public Nullable<int> NumeroEvaluacion { get; set; }
        public Nullable<int> PuntuacionTotalSkill { get; set; }
        public Nullable<int> EscalaTecnica { get; set; }
        public Nullable<int> PuntuacionTotalWill { get; set; }
        public Nullable<int> EscalaConductual { get; set; }
        public Nullable<int> ResultadoFinal { get; set; }
    }
}
