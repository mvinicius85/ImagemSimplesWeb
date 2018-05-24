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
           : base("PgProdutos")
        {
        }

        public DbSet<cad_mascaras> CAD_MASCARAS { get; set; }
        public DbSet<user_atributos> USER_ATRIBUTOS { get; set; }
        public DbSet<user_cadastro> USER_CADASTRO { get; set; }
        public DbSet<user_cadastro_modulos> USER_CADASTRO_MODULOS { get; set; }
        public DbSet<user_cat_atributos> USER_CAT_ATRIBUTOS { get; set; }
        public DbSet<user_doc_atributos> USER_DOC_ATRIBUTOS { get; set; }
        public DbSet<user_doc_retiradas> USER_DOC_RETIRADAS { get; set; }
        public DbSet<user_doc_vinculo> USER_DOC_VINCULO { get; set; }
        public DbSet<user_documentos> USER_DOCUMENTOS { get; set; }
        public DbSet<user_liberareq> USER_LIBERAREQ { get; set; }
        public DbSet<user_menu1> USER_MENU1 { get; set; }
        public DbSet<user_menuimagem> USER_MENUIMAGEM { get; set; }
        public DbSet<user_modulos> USER_MODULOS { get; set; }
        public DbSet<user_permissoes> USER_PERMISSOES { get; set; }
        public DbSet<user_operacoes> USER_OPERACOES { get; set; }
        public DbSet<user_qtde_escopo> USER_QTDE_ESCOPO { get; set; }
        public DbSet<user_validacoes> USER_VALIDACOES { get; set; }
        public DbSet<user_vinculos> USER_VINCULOS { get; set; }
        public DbSet<user_vinculos_atri> USER_VINCULOS_ATRI { get; set; }
        public DbSet<user_documentos_atributos> user_documentos_atributos { get; set; }
        public DbSet<user_documentos_imagem> user_documentos_imagem { get; set; }
        public DbSet<user_status_documento> user_status_documento { get; set; }
        public DbSet<user_tipo_arquivo> user_tipo_arquivo { get; set; }
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
            modelBuilder.Configurations.Add(new user_documentos_atributosMap());
            modelBuilder.Configurations.Add(new user_documentos_imagemMap());
            modelBuilder.Configurations.Add(new user_status_documentoMap());
            modelBuilder.Configurations.Add(new user_tipo_arquivoMap());

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
