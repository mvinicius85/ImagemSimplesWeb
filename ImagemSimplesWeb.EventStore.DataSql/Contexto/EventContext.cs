using ImagemSimplesWeb.EventStore.DataSql.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.EventStore.DataSql.Contexto
{
    public class EventContext : DbContext
    {
        public EventContext()
            : base("Data Source=OM30NBRH98KVVC\\SQLEXPRESS;Initial Catalog=Imagem_Itapevi;Persist Security Info=True;User ID=sa; Password=password123;MultipleActiveResultSets=True;App=RommanelSistemasLogs")

        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<EntityEvent> EntityEvents { get; set; }
        public DbSet<ExceptionEvent> ExceptionEvent { get; set; }
        public DbSet<AccessEvent> AccessEvent { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //EntityEvent
            modelBuilder.Entity<EntityEvent>().HasKey(t => t.Id);
            modelBuilder.Entity<EntityEvent>().Property(t => t.EntityName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<EntityEvent>().Property(t => t.Action)
              .IsRequired()
              .HasMaxLength(100);

            modelBuilder.Entity<EntityEvent>().Property(t => t.EntityId)
            .HasMaxLength(100);

            // modelBuilder.Entity<EntityEvent>().Property(t => t.Entity);

            modelBuilder.Entity<EntityEvent>().Property(t => t.UserNameComputer)
            .IsRequired()
            .HasMaxLength(100);
            modelBuilder.Entity<EntityEvent>().Property(t => t.CodigoUsuario)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<EntityEvent>().Property(t => t.HostName)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<EntityEvent>().Property(t => t.Ip)
              .IsRequired()
              .HasMaxLength(100);
            modelBuilder.Entity<EntityEvent>().Property(t => t.App)
       .IsRequired()
       .HasMaxLength(100);



            //modelBuilder.Entity<EntityEvent>().Property(t => t.EntityIdGuid)
            // .HasColumnAnnotation("Index",
            //      new IndexAnnotation(new IndexAttribute("IX_EntityIdGuid") { IsUnique = true }));
            //modelBuilder.Entity<EntityEvent>().Property(t => t.EntityId)               
            //    .HasMaxLength(20).HasColumnAnnotation( "Index",
            //         new IndexAnnotation(new IndexAttribute("IX_EntityId") { IsUnique = true }));

            //ExceptionEvent

            modelBuilder.Entity<ExceptionEvent>().HasKey(t => t.Id);
            modelBuilder.Entity<ExceptionEvent>().Property(t => t.App)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<ExceptionEvent>().Property(t => t.UserNameComputer)
           .IsRequired()
           .HasMaxLength(100);

            modelBuilder.Entity<ExceptionEvent>().Property(t => t.CodigoUsuario)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<ExceptionEvent>().Property(t => t.HostName)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<ExceptionEvent>().Property(t => t.Ip)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<ExceptionEvent>().Property(t => t.ExceptionType)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<ExceptionEvent>().Property(t => t.Method)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<ExceptionEvent>().Property(t => t.StackTrace)
           .IsRequired()
           .HasMaxLength(1000);


            ///Acesso
            ///
            modelBuilder.Entity<AccessEvent>().HasKey(t => t.Id);
            modelBuilder.Entity<AccessEvent>().Property(t => t.Form)
                .IsRequired()
              .HasMaxLength(100);
            modelBuilder.Entity<AccessEvent>().Property(t => t.TipoAcesso)
            .IsRequired()
            .HasMaxLength(100);
            modelBuilder.Entity<AccessEvent>().Property(t => t.UserNameComputer)
            .IsRequired()
            .HasMaxLength(100);
            modelBuilder.Entity<AccessEvent>().Property(t => t.CodigoUsuario)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<AccessEvent>().Property(t => t.HostName)
           .IsRequired()
           .HasMaxLength(100);
            modelBuilder.Entity<AccessEvent>().Property(t => t.Ip)
              .IsRequired()
              .HasMaxLength(100);
            modelBuilder.Entity<AccessEvent>().Property(t => t.App)
           .IsRequired()
           .HasMaxLength(100);


        }


    }

    public static class ChangeDb
    {
        public static void ChangeConnection(this EventContext context, string cn)
        {
            context.Database.Connection.ConnectionString = cn;
        }
    }
}
