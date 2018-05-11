using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_MODULOSMap : EntityTypeConfiguration<USER_MODULOS>
    {
        public USER_MODULOSMap()
        {
            // Primary Key
            this.HasKey(t => t.id_modulo);

            // Properties
            this.Property(t => t.id_modulo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nome_modulo)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("USER_MODULOS");
            this.Property(t => t.id_modulo).HasColumnName("id_modulo");
            this.Property(t => t.nome_modulo).HasColumnName("nome_modulo");
        }
    }
}
