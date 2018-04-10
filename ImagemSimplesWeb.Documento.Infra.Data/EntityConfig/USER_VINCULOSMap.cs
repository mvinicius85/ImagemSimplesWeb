using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_VINCULOSMap : EntityTypeConfiguration<USER_VINCULOS>
    {
        public USER_VINCULOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Nome_doc)
                .HasMaxLength(80);

            this.Property(t => t.Nome_ass)
                .HasMaxLength(80);

            this.Property(t => t.Arquivo_Trabalho)
                .HasMaxLength(180);

            this.Property(t => t.Arquivo_Base)
                .HasMaxLength(180);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("USER_VINCULOS");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Nome_doc).HasColumnName("Nome_doc");
            this.Property(t => t.Nome_ass).HasColumnName("Nome_ass");
            this.Property(t => t.Arquivo_Trabalho).HasColumnName("Arquivo_Trabalho");
            this.Property(t => t.Arquivo_Base).HasColumnName("Arquivo_Base");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
