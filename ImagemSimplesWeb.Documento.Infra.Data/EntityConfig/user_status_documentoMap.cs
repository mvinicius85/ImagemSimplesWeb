using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class user_status_documentoMap : EntityTypeConfiguration<user_status_documento>
    {
        public user_status_documentoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_status);

            // Properties
            this.Property(t => t.id_status)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("user_status_documento");
            this.Property(t => t.id_status).HasColumnName("id_status");
            this.Property(t => t.descricao).HasColumnName("descricao");
        }
    }
}
