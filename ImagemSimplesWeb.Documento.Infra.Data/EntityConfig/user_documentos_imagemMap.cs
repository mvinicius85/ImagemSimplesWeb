using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class user_documentos_imagemMap : EntityTypeConfiguration<user_documentos_imagem>
    {
        public user_documentos_imagemMap()
        {
            // Primary Key
            this.HasKey(t => t.id_documento);

            // Properties
            this.Property(t => t.titulo)
                .HasMaxLength(20);

            this.Property(t => t.endereco_imagem)
                .HasMaxLength(200);

            this.Property(t => t.hora_cadastro)
                .HasMaxLength(12);

            this.Property(t => t.hora_alteracao)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("user_documentos_imagem");
            this.Property(t => t.id_documento).HasColumnName("id_documento");
            this.Property(t => t.id_categoria).HasColumnName("id_categoria");
            this.Property(t => t.id_status).HasColumnName("id_status");
            this.Property(t => t.titulo).HasColumnName("titulo");
            this.Property(t => t.endereco_imagem).HasColumnName("endereco_imagem");
            this.Property(t => t.data_cadastro).HasColumnName("data_cadastro");
            this.Property(t => t.hora_cadastro).HasColumnName("hora_cadastro");
            this.Property(t => t.data_alteracao).HasColumnName("data_alteracao");
            this.Property(t => t.hora_alteracao).HasColumnName("hora_alteracao");
            this.Property(t => t.id_user_alteracao).HasColumnName("id_user_alteracao");
        }
    }
}
