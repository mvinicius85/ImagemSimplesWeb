using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_MENU1Map : EntityTypeConfiguration<USER_MENU1>
    {
        public USER_MENU1Map()
        {
            // Primary Key
            this.HasKey(t => t.id_Oper);

            // Properties
            this.Property(t => t.id_Oper)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Descricao)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.Analitico)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.ExisteMDB)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("USER_MENU1");
            this.Property(t => t.id_Oper).HasColumnName("id_Oper");
            this.Property(t => t.Dependencia).HasColumnName("Dependencia");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Cod_Ext).HasColumnName("Cod_Ext");
            this.Property(t => t.Nivel).HasColumnName("Nivel");
            this.Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            this.Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            this.Property(t => t.Empresa).HasColumnName("Empresa");
            this.Property(t => t.Analitico).HasColumnName("Analitico");
            this.Property(t => t.OperIncluiu).HasColumnName("OperIncluiu");
            this.Property(t => t.OperAlterou).HasColumnName("OperAlterou");
            this.Property(t => t.ExisteMDB).HasColumnName("ExisteMDB");
            this.Property(t => t.PATHIMAGENS).HasColumnName("PATHIMAGENS");

        }
    }
}
