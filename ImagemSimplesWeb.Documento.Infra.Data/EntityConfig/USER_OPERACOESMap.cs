using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_OPERACOESMap : EntityTypeConfiguration<USER_OPERACOES>
    {
        public USER_OPERACOESMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Descricao)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("USER_OPERACOES");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_Oper).HasColumnName("id_Oper");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Visualizar).HasColumnName("Visualizar");
            this.Property(t => t.Indexar).HasColumnName("Indexar");
            this.Property(t => t.Conferir).HasColumnName("Conferir");
            this.Property(t => t.Configurar).HasColumnName("Configurar");
            this.Property(t => t.Mover).HasColumnName("Mover");
            this.Property(t => t.Perfil).HasColumnName("Perfil");
            this.Property(t => t.Ferramentas).HasColumnName("Ferramentas");
            this.Property(t => t.Relatorios).HasColumnName("Relatorios");
            this.Property(t => t.livre1).HasColumnName("livre1");
            this.Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            this.Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            this.Property(t => t.OperIncluiu).HasColumnName("OperIncluiu");
            this.Property(t => t.OperAlterou).HasColumnName("OperAlterou");
            this.Property(t => t.cont_docs).HasColumnName("cont_docs");
        }
    }
}
