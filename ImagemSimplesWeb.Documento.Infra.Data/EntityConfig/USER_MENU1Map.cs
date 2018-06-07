using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_MENU1Map : EntityTypeConfiguration<user_menu1>
    {
        public USER_MENU1Map()
        {
            // Primary Key
            this.HasKey(t => t.id_oper);

            this.Property(t => t.descricao)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.analitico)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.existemdb)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.nome)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("dbo.user_menu1");
            this.Property(t => t.id_oper).HasColumnName("id_oper");
            this.Property(t => t.dependencia).HasColumnName("dependencia");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.cod_ext).HasColumnName("cod_ext");
            this.Property(t => t.nivel).HasColumnName("nivel");
            this.Property(t => t.datainclusao).HasColumnName("datainclusao");
            this.Property(t => t.dataalteracao).HasColumnName("dataalteracao");
            this.Property(t => t.empresa).HasColumnName("empresa");
            this.Property(t => t.analitico).HasColumnName("analitico");
            this.Property(t => t.operincluiu).HasColumnName("operincluiu");
            this.Property(t => t.operalterou).HasColumnName("operalterou");
            this.Property(t => t.existemdb).HasColumnName("existemdb");
            this.Property(t => t.pathimagens).HasColumnName("pathimagens");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.id_tipo_arquivo).HasColumnName("id_tipo_arquivo");
            this.Property(t => t.ind_ativo).HasColumnName("ind_ativo");
        }
    }
}
