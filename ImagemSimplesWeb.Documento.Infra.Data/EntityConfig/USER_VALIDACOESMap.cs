using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_VALIDACOESMap : EntityTypeConfiguration<user_validacoes>
    {
        public USER_VALIDACOESMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.id_user });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nome)
                .HasMaxLength(80);

            this.Property(t => t.sql)
                .HasMaxLength(280);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("user_validacoes");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.sql).HasColumnName("sql");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.id_user).HasColumnName("id_user");
        }
    }
}
