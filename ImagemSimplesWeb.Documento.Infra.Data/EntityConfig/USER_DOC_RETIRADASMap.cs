using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_DOC_RETIRADASMap : EntityTypeConfiguration<USER_DOC_RETIRADAS>
    {
        public USER_DOC_RETIRADASMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.documento, t.Solicitante, t.Dataretirada, t.Datadevolucao, t.status, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.documento)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Solicitante)
                .IsRequired()
                .HasMaxLength(180);

            this.Property(t => t.cpf_rg)
                .HasMaxLength(20);

            this.Property(t => t.status)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("USER_DOC_RETIRADAS");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.documento).HasColumnName("documento");
            this.Property(t => t.Solicitante).HasColumnName("Solicitante");
            this.Property(t => t.cpf_rg).HasColumnName("cpf_rg");
            this.Property(t => t.Dataretirada).HasColumnName("Dataretirada");
            this.Property(t => t.Datadevolucao).HasColumnName("Datadevolucao");
            this.Property(t => t.id_entregador).HasColumnName("id_entregador");
            this.Property(t => t.id_recebedor).HasColumnName("id_recebedor");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
