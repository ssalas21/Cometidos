//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cometidos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cometidos
    {
        public int IdCometidos { get; set; }
        public string Rut_fk { get; set; }
        public int IdDestino_FK { get; set; }
        public System.DateTime Fecha_cometido { get; set; }
        public Nullable<System.DateTime> Hora_salida { get; set; }
        public Nullable<System.DateTime> Hora_llegada { get; set; }
        public string Motivo { get; set; }
        public int Nulo { get; set; }
        public int Valor_destino_old { get; set; }
        public int Viatico { get; set; }
        public string NombreUsuario_FK { get; set; }
        public Nullable<int> Movilizacion { get; set; }
    
        public virtual Destino Destino { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
