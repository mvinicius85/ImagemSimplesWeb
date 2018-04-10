using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_MENUIMAGEMMap : EntityTypeConfiguration<USER_MENUIMAGEM>
    {
        public USER_MENUIMAGEMMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Documento)
                .IsFixedLength()
                .HasMaxLength(150);

            this.Property(t => t.Pasta)
                .IsFixedLength()
                .HasMaxLength(250);

            this.Property(t => t.imagem)
                .IsFixedLength()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("USER_MENUIMAGEM");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_doc).HasColumnName("id_doc");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Documento).HasColumnName("Documento");
            this.Property(t => t.Pasta).HasColumnName("Pasta");
            this.Property(t => t.imagem).HasColumnName("imagem");
            this.Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            this.Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            this.Property(t => t.OperIncluiu).HasColumnName("OperIncluiu");
            this.Property(t => t.OperAlterou).HasColumnName("OperAlterou");
        }
    }
}
