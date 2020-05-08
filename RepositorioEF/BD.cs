using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEF
{
    public class BD : DbContext
    {

        public DbSet<Usuario> usuarios { get; set; }
        public BD () : base("conexaoBD")
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Usuario>().Property(x=>x.nome).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Usuario>().Property(x=>x.cargo).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Usuario>().Property(x=>x.data).IsRequired().HasColumnType("date");
        }
    }
}
