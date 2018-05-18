using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_DOCUMENTOSMap : EntityTypeConfiguration<user_documentos>
    {
        public USER_DOCUMENTOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.atr_tam, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.posicao)
                .HasMaxLength(5);

            this.Property(t => t.atr_nome)
                .HasMaxLength(80);

            this.Property(t => t.atr_tipo)
                .HasMaxLength(80);

            this.Property(t => t.atr_tam)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.docext)
                .HasMaxLength(80);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("user_documentos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.posicao).HasColumnName("posicao");
            this.Property(t => t.atr_nome).HasColumnName("atr_nome");
            this.Property(t => t.atr_tipo).HasColumnName("atr_tipo");
            this.Property(t => t.atr_tam).HasColumnName("atr_tam");
            this.Property(t => t.docext).HasColumnName("docext");
            this.Property(t => t.validacao_id1).HasColumnName("validacao_id1");
            this.Property(t => t.validacao_id2).HasColumnName("validacao_id2");
            this.Property(t => t.validacao_id3).HasColumnName("validacao_id3");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
