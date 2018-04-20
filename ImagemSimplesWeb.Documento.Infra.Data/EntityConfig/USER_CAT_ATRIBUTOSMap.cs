using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_CAT_ATRIBUTOSMap : EntityTypeConfiguration<USER_CAT_ATRIBUTOS>
    {
        public USER_CAT_ATRIBUTOSMap()
        {
            // Primary Key
            this.HasKey(t => t.id_cat_atrib);

            // Properties
            this.Property(t => t.NomeAtributo)
                .HasMaxLength(100);

            this.Property(t => t.TituloAtributo)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("USER_CAT_ATRIBUTOS");
            this.Property(t => t.id_cat_atrib).HasColumnName("id_cat_atrib");
            this.Property(t => t.id_Oper).HasColumnName("id_Oper");
            this.Property(t => t.NomeAtributo).HasColumnName("NomeAtributo");
            this.Property(t => t.TituloAtributo).HasColumnName("TituloAtributo");
            this.Property(t => t.Ordem).HasColumnName("Ordem");
        }
    }
}
