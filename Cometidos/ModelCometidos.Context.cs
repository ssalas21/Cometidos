﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CometidosEntities : DbContext
    {
        public CometidosEntities()
            : base("name=CometidosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Afp> Afp { get; set; }
        public virtual DbSet<Cometidos> Cometidos { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Destino> Destino { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Escalafon> Escalafon { get; set; }
        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Isapre> Isapre { get; set; }
        public virtual DbSet<ValoresViaticos> ValoresViaticos { get; set; }
        public virtual DbSet<Vinculo> Vinculo { get; set; }
    }
}