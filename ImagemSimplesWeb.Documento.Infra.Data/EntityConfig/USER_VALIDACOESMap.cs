using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_VALIDACOESMap : EntityTypeConfiguration<USER_VALIDACOES>
    {
        public USER_VALIDACOESMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Nome)
                .HasMaxLength(80);

            this.Property(t => t.SQL)
                .HasMaxLength(280);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("USER_VALIDACOES");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.SQL).HasColumnName("SQL");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
