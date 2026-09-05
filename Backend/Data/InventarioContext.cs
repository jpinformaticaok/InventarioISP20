using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Backend.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext()
        {

        }

        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Pais> Paises { get; set; }

        //Creamos el metodo OnConfiguring para configurar la cadena de conexion a la base de datos PostgreSQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /* if (!optionsBuilder.IsConfigured)
            {
                // Configurar la cadena de conexión a la base de datos PostgreSQL
                //optionsBuilder.UseNpgsql();
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                //string cadenaConexion = configuration.GetConnectionString("postgresLocal");
                var cadenaConexion = configuration.GetConnectionString("postgresRemote");

                optionsBuilder.UseNpgsql(cadenaConexion);
            }*/
        }

        //Creamos el metodo OnModelCreating para insertar datos semilla en la tabla Clientes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Firstname = "Juan", Lastname = "Pérez", Dni = "12345678", Address = "Calle Falsa 123", LocalidadId = 4 },
                new Cliente { Id = 2, Firstname = "María", Lastname = "González", Dni = "87654321", Address = "Avenida Siempre Viva 456", LocalidadId = 4 },
                new Cliente { Id = 3, Firstname = "Pedro", Lastname = "López", Dni = "11223344", Address = "Callejón del Beso 789", LocalidadId = 4 }
            );

            //Cargamos los datos semilla para la tabla Localidades
            modelBuilder.Entity<Localidad>().HasData(
                new Localidad { Id = 1, Name = "Buenos Aires", ProvinciaId = 1 },
                new Localidad { Id = 2, Name = "Córdoba", ProvinciaId = 2 },
                new Localidad { Id = 3, Name = "Santa Fe", ProvinciaId = 3 },
                new Localidad { Id = 4, Name = "Rosario", ProvinciaId = 3 },
                new Localidad { Id = 5, Name = "San Justo", ProvinciaId = 3 }
            );

            modelBuilder.Entity<Provincia>().HasData(
                new Provincia { Id = 1, Name = "Buenos Aires" },
                new Provincia { Id = 2, Name = "Córdoba" },
                new Provincia { Id = 3, Name = "Santa Fe" }
            );

            modelBuilder.Entity<Pais>().HasData(
                new Pais { Id = 1, Name = "Argentina" },
                new Pais { Id = 2, Name = "Brasil" },
                new Pais { Id = 3, Name = "Chile" }
            );

            //Configuramos la propiedad created_at para que se genere automaticamente la fecha y hora de creacion del registro
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Created_at)
                .HasDefaultValueSql("NOW()");

            //configuramos los query filters para que solo se muestren los registros que no esten eliminados
            modelBuilder.Entity<Cliente>()
                .HasQueryFilter(c => !c.isDeleted);
            modelBuilder.Entity<Localidad>()
                .HasQueryFilter(l => !l.isDeleted);

            //FIlters for Provincia
            modelBuilder.Entity<Provincia>()
                .HasQueryFilter(p => !p.isDeleted);

            //Desactivamos la eliminacion en cascada para la relacion entre localidad y provincia usando Fluent API
            modelBuilder.Entity<Localidad>()
                .HasOne(l => l.Provincia)
                .WithMany()
                .HasForeignKey(l => l.ProvinciaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pais>()
                .HasQueryFilter(p => !p.isDeleted);
        }
    }
}

    
