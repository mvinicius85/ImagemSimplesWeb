using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_QTDE_ESCOPOMap : EntityTypeConfiguration<user_qtde_escopo>
    {
        public USER_QTDE_ESCOPOMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.documentos)
                .HasMaxLength(10);

            this.Property(t => t.imagens)
                .HasMaxLength(10);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("user_qtde_escopo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.documentos).HasColumnName("documentos");
            this.Property(t => t.imagens).HasColumnName("imagens");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
