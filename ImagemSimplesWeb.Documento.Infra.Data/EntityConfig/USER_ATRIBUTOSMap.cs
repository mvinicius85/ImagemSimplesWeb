using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_ATRIBUTOSMap : EntityTypeConfiguration<user_atributos>
    {
        public USER_ATRIBUTOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nome)
                .HasMaxLength(80);

            this.Property(t => t.tamanho)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.tipo)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("user_atributos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.tamanho).HasColumnName("tamanho");
            this.Property(t => t.tipo).HasColumnName("tipo");
            this.Property(t => t.uso).HasColumnName("uso");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
