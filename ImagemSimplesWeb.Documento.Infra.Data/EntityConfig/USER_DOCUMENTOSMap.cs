using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_DOCUMENTOSMap : EntityTypeConfiguration<USER_DOCUMENTOS>
    {
        public USER_DOCUMENTOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.Atr_tam, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.posicao)
                .HasMaxLength(5);

            this.Property(t => t.Atr_nome)
                .HasMaxLength(80);

            this.Property(t => t.Atr_tipo)
                .HasMaxLength(80);

            this.Property(t => t.Atr_tam)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DocExt)
                .HasMaxLength(80);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("USER_DOCUMENTOS");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.posicao).HasColumnName("posicao");
            this.Property(t => t.Atr_nome).HasColumnName("Atr_nome");
            this.Property(t => t.Atr_tipo).HasColumnName("Atr_tipo");
            this.Property(t => t.Atr_tam).HasColumnName("Atr_tam");
            this.Property(t => t.DocExt).HasColumnName("DocExt");
            this.Property(t => t.validacao_id1).HasColumnName("validacao_id1");
            this.Property(t => t.validacao_id2).HasColumnName("validacao_id2");
            this.Property(t => t.validacao_id3).HasColumnName("validacao_id3");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
