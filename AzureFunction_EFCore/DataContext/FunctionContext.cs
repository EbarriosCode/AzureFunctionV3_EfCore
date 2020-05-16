using AzureFunction_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace AzureFunction_EFCore.DataContext
{
    public class FunctionContext : DbContext
    {
        public FunctionContext(DbContextOptions<FunctionContext> options)
            :base(options)
        {}

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albumes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Insertar datos iniciales en la tabla Artista
            modelBuilder.Entity<Artista>()                                       
                                        .HasData(
                                            new Artista() { ArtistaID = 1, Nombre = "Ricardo Arjona" },
                                            new Artista() { ArtistaID = 2, Nombre = "Luis Miguel"},
                                            new Artista() { ArtistaID = 3, Nombre = "Kalimba" });

            // Insertar datos iniciales en la tabla Album
            modelBuilder.Entity<Album>()
                                        .HasData(
                                            new Album() 
                                            { 
                                                AlbumID = 1, 
                                                ArtistaID = 2, 
                                                Titulo = "Romance", 
                                                Anio = 1991, 
                                                Precio = 180 
                                            },
                                            new Album()
                                            {
                                                AlbumID = 2,
                                                ArtistaID = 1,
                                                Titulo = "Circo Soledad",
                                                Anio = 2017,
                                                Precio = 190
                                            },
                                            new Album()
                                            {
                                                AlbumID = 3,
                                                ArtistaID = 3,
                                                Titulo = "Aerosoul",
                                                Anio = 2004,
                                                Precio = 210
                                            });
        }
    }

    public class FunctionContextFactory : IDesignTimeDbContextFactory<FunctionContext>
    {     
        public FunctionContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FunctionContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new FunctionContext(optionsBuilder.Options);
        }
    }
}
