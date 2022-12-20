using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVendas.Models.Usuarios
{
    public partial class ContextoUsuarios : DbContext
    {
        public ContextoUsuarios()
            : base("name=Usuarios")
        {
        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .Property(e => e.NomeUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Senha)
                .IsUnicode(false);
        }
    }
}
