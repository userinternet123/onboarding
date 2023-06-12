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
    
    public partial class TAsignacion
    {
        public int IdRecursoPuestoEmpleado { get; set; }
        public Nullable<bool> TipoAsignacion { get; set; }
        public Nullable<int> IdRecurso { get; set; }
        public Nullable<int> IdPuesto { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public string UsuarioInserto { get; set; }
        public Nullable<System.DateTime> FechaInserto { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
        public Nullable<bool> Eliminado { get; set; }
    
        public virtual TColaborador TColaborador { get; set; }
        public virtual TPuesto TPuesto { get; set; }
        public virtual TRecurso TRecurso { get; set; }
    }
}
