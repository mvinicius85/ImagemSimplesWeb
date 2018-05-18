using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_DOC_ATRIBUTOSMap : EntityTypeConfiguration<user_doc_atributos>
    {
        public USER_DOC_ATRIBUTOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_doc, t.id_atr, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_doc)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_atr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.validar)
                .HasMaxLength(25);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("user_doc_atributos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_doc).HasColumnName("id_doc");
            this.Property(t => t.id_atr).HasColumnName("id_atr");
            this.Property(t => t.validar).HasColumnName("validar");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
