using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_OPERACOESMap : EntityTypeConfiguration<user_operacoes>
    {
        public USER_OPERACOESMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descricao)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("user_operacoes");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_oper).HasColumnName("id_oper");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.visualizar).HasColumnName("visualizar");
            this.Property(t => t.indexar).HasColumnName("indexar");
            this.Property(t => t.conferir).HasColumnName("conferir");
            this.Property(t => t.configurar).HasColumnName("configurar");
            this.Property(t => t.mover).HasColumnName("mover");
            this.Property(t => t.perfil).HasColumnName("perfil");
            this.Property(t => t.ferramentas).HasColumnName("ferramentas");
            this.Property(t => t.relatorios).HasColumnName("relatorios");
            this.Property(t => t.livre1).HasColumnName("livre1");
            this.Property(t => t.datainclusao).HasColumnName("datainclusao");
            this.Property(t => t.dataalteracao).HasColumnName("dataalteracao");
            this.Property(t => t.operincluiu).HasColumnName("operincluiu");
            this.Property(t => t.operalterou).HasColumnName("operalterou");
            this.Property(t => t.cont_docs).HasColumnName("cont_docs");
        }
    }
}
