using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_CAT_ATRIBUTOSMap : EntityTypeConfiguration<user_cat_atributos>
    {
        public USER_CAT_ATRIBUTOSMap()
        {
            // Primary Key
            this.HasKey(t => t.id_cat_atrib);

            // Properties
            this.Property(t => t.nomeatributo)
                .HasMaxLength(100);

            this.Property(t => t.tituloatributo)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("user_cat_atributos");
            this.Property(t => t.id_cat_atrib).HasColumnName("id_cat_atrib");
            this.Property(t => t.id_oper).HasColumnName("id_oper");
            this.Property(t => t.nomeatributo).HasColumnName("nomeatributo");
            this.Property(t => t.tituloatributo).HasColumnName("tituloatributo");
            this.Property(t => t.ordem).HasColumnName("ordem");
        }
    }
}
