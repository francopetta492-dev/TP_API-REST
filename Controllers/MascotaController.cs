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

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(mascotas);
    }

    [HttpGet("{Id}")]
    public IActionResult GetById(int Id) 
    {
        foreach(Mascota m in mascotas)
        {
            if(m.Id == Id)
            {
                return Ok(m);
            }      
        }
        return NotFound("Producto no entontrado");   
    }

    [HttpPost("Perros")]
    public IActionResult Create([FromBody]Perro NuevoPerro)
    {
        mascotas.Add(NuevoPerro);
        return Ok("Mascota creada Exitosamente");
    }

    [HttpPost("Gatos")]
    public IActionResult Create([FromBody]Gato NuevoGato)
    {
        mascotas.Add(NuevoGato);
        return Ok("Mascota creada Exitosamente");
    }

     [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody]Mascota mascotaActualizada)
    {
        foreach(Mascota m in mascotas)
        {
            if(m.Id == id)
            {
                m.Nombre = mascotaActualizada.Nombre;
                m.Edad = mascotaActualizada.Edad;

                if(m is Perro)
                {
                    ((Perro)m).Raza = ((Perro)mascotaActualizada).Raza;
                }
                else if(m is Gato)
                {
                    ((Gato)m).Color = ((Gato)mascotaActualizada).Color;
                }

                return Ok("Mascota actualizada exitosamente");
            }
        }
        return NotFound("Mascota no encontrada");
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
}
