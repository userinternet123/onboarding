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
    
    public partial class TDetalleEvaluacion
    {
        public int IdDetalleEvaluacion { get; set; }
        public Nullable<int> IdActividad { get; set; }
        public Nullable<int> IdPlanOnBoarding { get; set; }
        public string UsuarioInserto { get; set; }
        public Nullable<System.DateTime> FechaInserto { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
        public Nullable<bool> Eliminado { get; set; }
        public Nullable<int> Nota { get; set; }
    
        public virtual TActividad TActividad { get; set; }
        public virtual TPlanOnBoarding TPlanOnBoarding { get; set; }
    }
}
