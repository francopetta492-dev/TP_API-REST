using Microsoft.AspNetCore.Mvc;

namespace TP_API_PETTA_FRANCO.Controllers;

[ApiController]
[Route("[controller]")]
public class MascotaController : ControllerBase
{
    private static readonly List<Mascota> mascotas = new() 
    {
        new Perro{Id = 1, Nombre = "Firulais", Edad = 5, Raza = "Labrador"},
        new Perro{Id = 2, Nombre = "Rocky", Edad = 8, Raza = "Salchicha"},
        new Gato{Id = 3, Nombre = "Luna", Edad = 3, Color = "Naranja"},
        new Gato{Id = 4, Nombre = "Michi", Edad = 10, Color = "Marron"},  
    };
    private readonly ILogger<MascotaController> _logger;

    public MascotaController(ILogger<MascotaController> logger)
    {
        _logger = logger;
    }

    
}
