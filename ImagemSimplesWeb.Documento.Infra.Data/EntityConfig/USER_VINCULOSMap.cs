using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_VINCULOSMap : EntityTypeConfiguration<user_vinculos>
    {
        public USER_VINCULOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nome_doc)
                .HasMaxLength(80);

            this.Property(t => t.nome_ass)
                .HasMaxLength(80);

            this.Property(t => t.arquivo_trabalho)
                .HasMaxLength(180);

            this.Property(t => t.arquivo_base)
                .HasMaxLength(180);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("user_vinculos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nome_doc).HasColumnName("nome_doc");
            this.Property(t => t.nome_ass).HasColumnName("nome_ass");
            this.Property(t => t.arquivo_trabalho).HasColumnName("arquivo_trabalho");
            this.Property(t => t.arquivo_base).HasColumnName("arquivo_base");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
