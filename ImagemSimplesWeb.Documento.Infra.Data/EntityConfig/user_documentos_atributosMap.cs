using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class user_documentos_atributosMap : EntityTypeConfiguration<user_documentos_atributos>
    {
        public user_documentos_atributosMap()
        {
            // Primary Key
            this.HasKey(t => t.id_doc_atrib);

            // Properties
            this.Property(t => t.valor)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("user_documentos_atributos");
            this.Property(t => t.id_doc_atrib).HasColumnName("id_doc_atrib");
            this.Property(t => t.id_documento).HasColumnName("id_documento");
            this.Property(t => t.id_atributo).HasColumnName("id_atributo");
            this.Property(t => t.valor).HasColumnName("valor");
        }
    }
}
