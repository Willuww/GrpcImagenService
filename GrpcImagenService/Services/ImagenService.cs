using Grpc.Core;
using GrpcImagenService.Modelo;
using GrpcImagenService.Persistencia;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcImagenService.Services
{
    /* Define el servicio gRPC que maneja las operaciones relacionadas con imágenes */
    public class ImagenService : AutorImagenService.AutorImagenServiceBase
    {
        private readonly ContextoImagen _contexto;

        public ImagenService(ContextoImagen contexto)
        {
            _contexto = contexto;
        }

        /* Implementa el método para guardar una imagen en la base de datos */
        public override async Task<Respuesta> GuardarImagen(ImagenRequest request, ServerCallContext context)
        {
            try
            {
                /* Crea una nueva entidad de Imagen con el contenido recibido */
                var imagen = new Imagen
                {
                    Contenido = request.Contenido.ToByteArray()
                };

                /* Agrega la imagen a la base de datos y guarda los cambios */
                _contexto.Imagenes.Add(imagen);
                await _contexto.SaveChangesAsync();

                /* Retorna un mensaje de éxito */
                return new Respuesta { Mensaje = "Imagen guardada correctamente." };
            }
            catch (Exception ex)
            {
                /* Maneja cualquier error y devuelve un mensaje de error */
                return new Respuesta { Mensaje = "Error al guardar la imagen: " + ex.Message };
            }
        }
    }
}
