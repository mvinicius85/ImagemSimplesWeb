using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_PERMISSOESMap : EntityTypeConfiguration<user_permissoes>
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

            this.Property(t => t.nivel)
                .HasMaxLength(80);

            this.Property(t => t.observacao)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("user_permissoes");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.id_oper).HasColumnName("id_oper");
            this.Property(t => t.sub_oper).HasColumnName("sub_oper");
            this.Property(t => t.nivel).HasColumnName("nivel");
            this.Property(t => t.acesso).HasColumnName("acesso");
            this.Property(t => t.incluir).HasColumnName("incluir");
            this.Property(t => t.alterar).HasColumnName("alterar");
            this.Property(t => t.excluir).HasColumnName("excluir");
            this.Property(t => t.inativar).HasColumnName("inativar");
            this.Property(t => t.observacao).HasColumnName("observacao");

            // Relationships
  

        }
    }
}
