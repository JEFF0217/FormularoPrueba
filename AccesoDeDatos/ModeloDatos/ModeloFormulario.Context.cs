﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDeDatos.ModeloDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FormularioDBEntities : DbContext
    {
        public FormularioDBEntities()
            : base("name=FormularioDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_ciudad> tb_ciudad { get; set; }
        public virtual DbSet<tb_TipoDoc> tb_TipoDoc { get; set; }
        public virtual DbSet<tb_usuario> tb_usuario { get; set; }
    }
}