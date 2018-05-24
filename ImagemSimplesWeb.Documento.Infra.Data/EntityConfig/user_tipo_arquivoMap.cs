using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class user_tipo_arquivoMap : EntityTypeConfiguration<user_tipo_arquivo>
    {
        public user_tipo_arquivoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_tipo_arquivo);

            // Properties
            this.Property(t => t.id_tipo_arquivo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descricao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("user_tipo_arquivo");
            this.Property(t => t.id_tipo_arquivo).HasColumnName("id_tipo_arquivo");
            this.Property(t => t.descricao).HasColumnName("descricao");
        }
    }
}
