using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_ATRIBUTOSMap : EntityTypeConfiguration<USER_ATRIBUTOS>
    {
        public USER_ATRIBUTOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Nome)
                .HasMaxLength(80);

            this.Property(t => t.Tamanho)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Tipo)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("USER_ATRIBUTOS");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Tamanho).HasColumnName("Tamanho");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Uso).HasColumnName("Uso");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
