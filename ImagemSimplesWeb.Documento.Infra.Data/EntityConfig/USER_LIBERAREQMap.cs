using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_LIBERAREQMap : EntityTypeConfiguration<USER_LIBERAREQ>
    {
        public USER_LIBERAREQMap()
        {
            // Primary Key
            this.HasKey(t => t.id_user);

            // Properties
            this.Property(t => t.codigo)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Nome)
                .HasMaxLength(50);

            this.Property(t => t.Depto)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Data)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("USER_LIBERAREQ");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Depto).HasColumnName("Depto");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Libera).HasColumnName("Libera");
        }
    }
}
