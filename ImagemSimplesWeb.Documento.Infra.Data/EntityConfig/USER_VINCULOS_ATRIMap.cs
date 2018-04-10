using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_VINCULOS_ATRIMap : EntityTypeConfiguration<USER_VINCULOS_ATRI>
    {
        public USER_VINCULOS_ATRIMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_ass, t.id_user });

            // Properties
            this.Property(t => t.id_ass)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Atr_Trabalho)
                .HasMaxLength(80);

            this.Property(t => t.Atr_Base)
                .HasMaxLength(80);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("USER_VINCULOS_ATRI");
            this.Property(t => t.id_ass).HasColumnName("id_ass");
            this.Property(t => t.Atr_Trabalho).HasColumnName("Atr_Trabalho");
            this.Property(t => t.Atr_Base).HasColumnName("Atr_Base");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
