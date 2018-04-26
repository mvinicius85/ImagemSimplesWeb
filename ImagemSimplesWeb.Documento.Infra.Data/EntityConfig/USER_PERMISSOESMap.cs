using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_PERMISSOESMap : EntityTypeConfiguration<USER_PERMISSOES>
    {
        public USER_PERMISSOESMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_user, t.id_oper });

            // Properties
            this.Property(t => t.id_user)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.id_oper)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sub_oper)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Nivel)
                .HasMaxLength(80);

            this.Property(t => t.Observacao)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("USER_PERMISSOES");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.id_oper).HasColumnName("id_oper");
            this.Property(t => t.sub_oper).HasColumnName("sub_oper");
            this.Property(t => t.Nivel).HasColumnName("Nivel");
            this.Property(t => t.Acesso).HasColumnName("Acesso");
            this.Property(t => t.Incluir).HasColumnName("Incluir");
            this.Property(t => t.Alterar).HasColumnName("Alterar");
            this.Property(t => t.Excluir).HasColumnName("Excluir");
            this.Property(t => t.Inativar).HasColumnName("Inativar");
            this.Property(t => t.Observacao).HasColumnName("Observacao");

            // Relationships
  

        }
    }
}
