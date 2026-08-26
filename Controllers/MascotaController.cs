using Microsoft.AspNetCore.Mvc;

namespace TP_API_PETTA_FRANCO;

[ApiController]
[Route("[controller]")]
public class MascotaController : ControllerBase
{
    private static readonly List<Mascota> mascotas = new()
    {
        new Perro { Id = 1, Nombre = "Firulas", Edad = 5, Raza = "Labrador" },
        new Gato { Id = 2, Nombre = "Luna", Edad = 3, Color = "Naranja" },
        new Perro { Id = 3, Nombre = "Rocky", Edad = 8, Raza = "Salchicha" },
        new Gato { Id = 4, Nombre = "Michi", Edad = 10, Color = "Negro" }
    };


    private readonly ILogger<MascotaController> _logger;

    public MascotaController(ILogger<MascotaController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(mascotas);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        foreach(Mascota m in mascotas)
        {
            if(m.Id == id)
            {
                return Ok(m);
            }
        }
        return NotFound("Mascota no encontrada");
    }

    [HttpGet("mayores-a/{edad}")]
    public IActionResult GetByEdad(int edad)
    {
        List<Mascota> mascotasMayores = new();

        foreach (Mascota m in mascotas)
        {
            if (m.Edad > edad)
            {
                mascotasMayores.Add(m);
            }
        }

        if (mascotasMayores.Count == 0)
        {
            return NotFound("No hay mascotas mayores a esa edad");
        }

        return Ok(mascotasMayores);
    }

    [HttpGet("tipo/{tipo}")]
    public IActionResult GetByTipo(string tipo)
    {
        List<Mascota> tipos = new();

        foreach (Mascota m in mascotas)
        {
            if(tipo.ToLower() == "perro" && m is Perro)
            {
                tipos.Add(m);
            }
            else if(tipo.ToLower() == "gato" && m is Gato)
            {
                tipos.Add(m);
            }
        }

        if (tipos.Count == 0)
        {
            return NotFound("No hay mascotas del tipo especificado");
        }

        return Ok(tipos);
    }
    
    [HttpPost("perros")]
    public IActionResult CreatePerro([FromBody]Perro nuevoPerro)
    {
        mascotas.Add(nuevoPerro);
        return Ok("Perro creado exitosamente");
    }

    [HttpPost("gatos")]
    public IActionResult CreateGatos([FromBody]Gato nuevoGato)
    {
        mascotas.Add(nuevoGato);
        return Ok("Gato creado exitosamente");
    }

    [HttpPut("perro/{id}")]
    public IActionResult UpdatePerro(int id, [FromBody] Perro perroActualizado)
    {
        foreach (Mascota m in mascotas)
        {
            if (m.Id == id && m is Perro perro)
            {
                perro.Nombre = perroActualizado.Nombre;
                perro.Edad = perroActualizado.Edad;
                perro.Raza = perroActualizado.Raza;

                return Ok("Perro actualizado exitosamente");
            }
        }

        return NotFound("Perro no encontrado");
    }

    [HttpPut("gato/{id}")]
    public IActionResult UpdateGato(int id, [FromBody] Gato gatoActualizado)
    {
        foreach (Mascota m in mascotas)
        {
            if (m.Id == id && m is Gato gato)
            {
                gato.Nombre = gatoActualizado.Nombre;
                gato.Edad = gatoActualizado.Edad;
                gato.Color = gatoActualizado.Color;

                return Ok("Gato actualizado exitosamente");
            }
        }

        return NotFound("Gato no encontrado");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        foreach(Mascota m in mascotas)
        {
            if(m.Id == id)
            {
                mascotas.Remove(m);
                return Ok("Mascota eliminada exitosamente");
            }
        }
        return NotFound("Mascota no encontrada");
    }
    
}
