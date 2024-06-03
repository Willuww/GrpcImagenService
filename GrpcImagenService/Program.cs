using GrpcImagenService.Persistencia;
using GrpcImagenService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor
builder.Services.AddGrpc();
builder.Services.AddDbContext<ContextoImagen>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configura el pipeline de solicitudes HTTP
app.MapGrpcService<ImagenService>();
app.MapGet("/", () => "La comunicación con los endpoints gRPC debe realizarse a través de un cliente gRPC. Para aprender cómo crear un cliente, visita: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
