using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_CADASTROMap : EntityTypeConfiguration<USER_CADASTRO>
    {
        public USER_CADASTROMap()
        {
            // Primary Key
            this.HasKey(t => t.id_user);

            // Properties
            this.Property(t => t.codigo)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Nome)
                .HasMaxLength(80);

            this.Property(t => t.Depto)
                .IsFixedLength()
                .HasMaxLength(80);

            this.Property(t => t.Data)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.DataInicio)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.Tel1)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.Tel2)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.Tel3)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Senha)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.LiberaRequisicao)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Assinatura)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.nomepc)
                .HasMaxLength(50);

            this.Property(t => t.secao)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("USER_CADASTRO");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Depto).HasColumnName("Depto");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.DataInicio).HasColumnName("DataInicio");
            this.Property(t => t.Tel1).HasColumnName("Tel1");
            this.Property(t => t.Tel2).HasColumnName("Tel2");
            this.Property(t => t.Tel3).HasColumnName("Tel3");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.LiberaRequisicao).HasColumnName("LiberaRequisicao");
            this.Property(t => t.Assinatura).HasColumnName("Assinatura");
            this.Property(t => t.nomepc).HasColumnName("nomepc");
            this.Property(t => t.secao).HasColumnName("secao");
            this.Property(t => t.ativo).HasColumnName("ativo");
        }
    }
}
