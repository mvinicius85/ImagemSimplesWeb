using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using ImagemSimplesWeb.Documento.Infra.Data.EntityConfig;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;

namespace ImagemSimplesWeb.Documento.Infra.Data.Contexto
{
    public partial class Imagem_ItapeviContext : DbContext
    {
        static Imagem_ItapeviContext()
        {
            Database.SetInitializer<Imagem_ItapeviContext>(null);
        }

        public Imagem_ItapeviContext()
           : base("Data Source=OM30NBRH98KVVC\\SQLEXPRESS;Initial Catalog=Imagem_Itapevi;Persist Security Info=True;User ID=sa; Password=password123;MultipleActiveResultSets=True;App=ImagemSimplesWeb")
        {
        }

        public DbSet<CAD_MASCARAS> CAD_MASCARAS { get; set; }
        public DbSet<USER_ATRIBUTOS> USER_ATRIBUTOS { get; set; }
        public DbSet<USER_CADASTRO> USER_CADASTRO { get; set; }
        public DbSet<USER_CADASTRO_MODULOS> USER_CADASTRO_MODULOS { get; set; }
        public DbSet<USER_CAT_ATRIBUTOS> USER_CAT_ATRIBUTOS { get; set; }
        public DbSet<USER_DOC_ATRIBUTOS> USER_DOC_ATRIBUTOS { get; set; }
        public DbSet<USER_DOC_RETIRADAS> USER_DOC_RETIRADAS { get; set; }
        public DbSet<USER_DOC_VINCULO> USER_DOC_VINCULO { get; set; }
        public DbSet<USER_DOCUMENTOS> USER_DOCUMENTOS { get; set; }
        public DbSet<USER_LIBERAREQ> USER_LIBERAREQ { get; set; }
        public DbSet<USER_MENU1> USER_MENU1 { get; set; }
        public DbSet<USER_MENUIMAGEM> USER_MENUIMAGEM { get; set; }
        public DbSet<USER_MODULOS> USER_MODULOS { get; set; }
        public DbSet<USER_PERMISSOES> USER_PERMISSOES { get; set; }
        public DbSet<USER_OPERACOES> USER_OPERACOES { get; set; }
        public DbSet<USER_QTDE_ESCOPO> USER_QTDE_ESCOPO { get; set; }
        public DbSet<USER_VALIDACOES> USER_VALIDACOES { get; set; }
        public DbSet<USER_VINCULOS> USER_VINCULOS { get; set; }
        public DbSet<USER_VINCULOS_ATRI> USER_VINCULOS_ATRI { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CAD_MASCARASMap());
            modelBuilder.Configurations.Add(new USER_ATRIBUTOSMap());
            modelBuilder.Configurations.Add(new USER_CADASTROMap());
            modelBuilder.Configurations.Add(new USER_CADASTRO_MODULOSMap());
            modelBuilder.Configurations.Add(new USER_CAT_ATRIBUTOSMap());
            modelBuilder.Configurations.Add(new USER_DOC_ATRIBUTOSMap());
            modelBuilder.Configurations.Add(new USER_DOC_RETIRADASMap());
            modelBuilder.Configurations.Add(new USER_DOC_VINCULOMap());
            modelBuilder.Configurations.Add(new USER_DOCUMENTOSMap());
            modelBuilder.Configurations.Add(new USER_LIBERAREQMap());
            modelBuilder.Configurations.Add(new USER_MENU1Map());
            modelBuilder.Configurations.Add(new USER_MENUIMAGEMMap());
            modelBuilder.Configurations.Add(new USER_MODULOSMap());
            modelBuilder.Configurations.Add(new USER_OPERACOESMap());
            modelBuilder.Configurations.Add(new USER_PERMISSOESMap());
            modelBuilder.Configurations.Add(new USER_QTDE_ESCOPOMap());
            modelBuilder.Configurations.Add(new USER_VALIDACOESMap());
            modelBuilder.Configurations.Add(new USER_VINCULOSMap());
            modelBuilder.Configurations.Add(new USER_VINCULOS_ATRIMap());
        }

        public override int SaveChanges()
        {



            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dat_inc") != null))
            {


                if (entry.State == EntityState.Added)
                {
                    entry.Property("dat_inc").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("dat_inc").IsModified = false;
                }
            }

            var rowsaffected = base.SaveChanges();

            return rowsaffected;
        }


    }



    public static class ChangeDb
    {
        public static void ChangeConnection(this Imagem_ItapeviContext context, string cn)
        {
            context.Database.Connection.ConnectionString = cn;
        }
    }

}
