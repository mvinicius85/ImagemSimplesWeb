using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_MENUIMAGEMMap : EntityTypeConfiguration<user_menuimagem>
    {
        public USER_MENUIMAGEMMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.documento)
                .IsFixedLength()
                .HasMaxLength(150);

            this.Property(t => t.pasta)
                .IsFixedLength()
                .HasMaxLength(250);

            this.Property(t => t.imagem)
                .IsFixedLength()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("user_menuimagem");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_doc).HasColumnName("id_doc");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.documento).HasColumnName("documento");
            this.Property(t => t.pasta).HasColumnName("pasta");
            this.Property(t => t.imagem).HasColumnName("imagem");
            this.Property(t => t.datainclusao).HasColumnName("datainclusao");
            this.Property(t => t.dataalteracao).HasColumnName("dataalteracao");
            this.Property(t => t.operincluiu).HasColumnName("operincluiu");
            this.Property(t => t.operalterou).HasColumnName("operalterou");
        }
    }
}
