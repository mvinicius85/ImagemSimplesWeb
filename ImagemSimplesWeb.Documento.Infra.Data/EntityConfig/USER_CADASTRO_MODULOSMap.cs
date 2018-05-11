using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_CADASTRO_MODULOSMap : EntityTypeConfiguration<USER_CADASTRO_MODULOS>
    {
        public USER_CADASTRO_MODULOSMap()
        {
            // Primary Key
            this.HasKey(t => t.id_cadastro_modulo);

            // Properties
            // Table & Column Mappings
            this.ToTable("USER_CADASTRO_MODULOS");
            this.Property(t => t.id_cadastro_modulo).HasColumnName("id_cadastro_modulo");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.id_modulo).HasColumnName("id_modulo");
        }
    }
}
