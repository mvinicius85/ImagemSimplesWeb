using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_LIBERAREQMap : EntityTypeConfiguration<user_liberareq>
    {
        public USER_LIBERAREQMap()
        {
            // Primary Key
            this.HasKey(t => t.id_user);

            // Properties
            this.Property(t => t.codigo)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.nome)
                .HasMaxLength(50);

            this.Property(t => t.depto)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.data)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("user_liberareq");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.depto).HasColumnName("depto");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.libera).HasColumnName("libera");
        }
    }
}
