using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_VINCULOS_ATRIMap : EntityTypeConfiguration<user_vinculos_atri>
    {
        public USER_VINCULOS_ATRIMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_ass, t.id_user });

            // Properties
            this.Property(t => t.id_ass)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.atr_trabalho)
                .HasMaxLength(80);

            this.Property(t => t.atr_base)
                .HasMaxLength(80);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("user_vinculos_atri");
            this.Property(t => t.id_ass).HasColumnName("id_ass");
            this.Property(t => t.atr_trabalho).HasColumnName("atr_trabalho");
            this.Property(t => t.atr_base).HasColumnName("atr_base");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
