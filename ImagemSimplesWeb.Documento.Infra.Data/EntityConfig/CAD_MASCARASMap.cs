using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class CAD_MASCARASMap : EntityTypeConfiguration<cad_mascaras>
    {
        public CAD_MASCARASMap()
        {
            // Primary Key
            this.HasKey(t => t.id_oper);

            // Properties
            this.Property(t => t.descricao)
                .HasMaxLength(50);

            this.Property(t => t.tabela)
                .HasMaxLength(50);

            this.Property(t => t.nivel)
                .HasMaxLength(40);

            this.Property(t => t.mascara)
                .HasMaxLength(50);

            this.Property(t => t.analitico)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.utilizada)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("cad_mascaras");
            this.Property(t => t.id_oper).HasColumnName("id_oper");
            this.Property(t => t.dependencia).HasColumnName("dependencia");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.tabela).HasColumnName("tabela");
            this.Property(t => t.nivel).HasColumnName("nivel");
            this.Property(t => t.subniveis).HasColumnName("subniveis");
            this.Property(t => t.mascara).HasColumnName("mascara");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.datainclusao).HasColumnName("datainclusao");
            this.Property(t => t.dataalteracao).HasColumnName("dataalteracao");
            this.Property(t => t.empresa).HasColumnName("empresa");
            this.Property(t => t.analitico).HasColumnName("analitico");
            this.Property(t => t.operincluiu).HasColumnName("operincluiu");
            this.Property(t => t.operalterou).HasColumnName("operalterou");
            this.Property(t => t.utilizada).HasColumnName("utilizada");
        }
    }
}
