using System.ComponentModel.DataAnnotations.Schema;

namespace GrpcImagenService.Modelo
{
    /* Define la estructura de la tabla "imagen" en la base de datos */
    [Table("imagen")]
    public class Imagen
    {
        /* Identificador único de la imagen */
        public int Id { get; set; }

        /* Contenido de la imagen en forma de bytes */
        public byte[] Contenido { get; set; }
    }
}
