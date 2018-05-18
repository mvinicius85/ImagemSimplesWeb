using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ImagemSimplesWeb.Documento.Infra.Data.EntityConfig
{
    public class USER_CADASTROMap : EntityTypeConfiguration<user_cadastro>
    {
        public USER_CADASTROMap()
        {
            // Primary Key
            this.HasKey(t => t.id_user);

            // Properties
            this.Property(t => t.codigo)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.nome)
                .HasMaxLength(80);

            this.Property(t => t.depto)
                .IsFixedLength()
                .HasMaxLength(80);

            this.Property(t => t.data)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.datainicio)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.tel1)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.tel2)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.tel3)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.senha)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.liberarequisicao)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.assinatura)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.nomepc)
                .HasMaxLength(50);

            this.Property(t => t.secao)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("user_cadastro");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.depto).HasColumnName("depto");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.datainicio).HasColumnName("datainicio");
            this.Property(t => t.tel1).HasColumnName("tel1");
            this.Property(t => t.tel2).HasColumnName("tel2");
            this.Property(t => t.tel3).HasColumnName("tel3");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.senha).HasColumnName("senha");
            this.Property(t => t.liberarequisicao).HasColumnName("liberarequisicao");
            this.Property(t => t.assinatura).HasColumnName("assinatura");
            this.Property(t => t.nomepc).HasColumnName("nomepc");
            this.Property(t => t.secao).HasColumnName("secao");
            this.Property(t => t.ativo).HasColumnName("ativo");
        }
    }
}
