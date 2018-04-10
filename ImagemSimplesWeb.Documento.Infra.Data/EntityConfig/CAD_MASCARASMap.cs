using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class CAD_MASCARASMap : EntityTypeConfiguration<CAD_MASCARAS>
    {
        public CAD_MASCARASMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Oper);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(50);

            this.Property(t => t.Tabela)
                .HasMaxLength(50);

            this.Property(t => t.Nivel)
                .HasMaxLength(40);

            this.Property(t => t.Mascara)
                .HasMaxLength(50);

            this.Property(t => t.Analitico)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.Utilizada)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("CAD_MASCARAS");
            this.Property(t => t.id_Oper).HasColumnName("id_Oper");
            this.Property(t => t.Dependencia).HasColumnName("Dependencia");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Tabela).HasColumnName("Tabela");
            this.Property(t => t.Nivel).HasColumnName("Nivel");
            this.Property(t => t.SubNiveis).HasColumnName("SubNiveis");
            this.Property(t => t.Mascara).HasColumnName("Mascara");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            this.Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            this.Property(t => t.Empresa).HasColumnName("Empresa");
            this.Property(t => t.Analitico).HasColumnName("Analitico");
            this.Property(t => t.OperIncluiu).HasColumnName("OperIncluiu");
            this.Property(t => t.OperAlterou).HasColumnName("OperAlterou");
            this.Property(t => t.Utilizada).HasColumnName("Utilizada");
        }
    }
}
