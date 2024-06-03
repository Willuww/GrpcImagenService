using Microsoft.EntityFrameworkCore;
using GrpcImagenService.Modelo;

namespace GrpcImagenService.Persistencia
{
    /* Define el contexto de la base de datos que contiene la tabla de imágenes */
    public class ContextoImagen : DbContext
    {
        /* Constructor que recibe opciones de configuración de DbContext */
        public ContextoImagen(DbContextOptions<ContextoImagen> options) : base(options)
        {
        }

        /* Representa la tabla "imagen" en la base de datos */
        public DbSet<Imagen> Imagenes { get; set; }
    }
}
