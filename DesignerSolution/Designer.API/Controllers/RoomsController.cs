using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase {
    private readonly IRoomRepository _repositorio;

    public RoomsController(IRoomRepository repositorio) {
        _repositorio = repositorio;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos() => Ok(await _repositorio.ObtenerTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Obtener(int id) {
        var room = await _repositorio.ObtenerPorIdAsync(id);
        if (room == null) return NotFound();
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Room room) {
        await _repositorio.AgregarAsync(room);
        return CreatedAtAction(nameof(Obtener), new { id = room.Id }, room);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, Room roomActualizado) {
        var room = await _repositorio.ObtenerPorIdAsync(id);
        if (room == null) return NotFound();
        room.Nombre = roomActualizado.Nombre;
        room.Ancho = roomActualizado.Ancho;
        room.Alto = roomActualizado.Alto;
        await _repositorio.ActualizarAsync(room);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id) {
        await _repositorio.EliminarAsync(id);
        return NoContent();
    }
}
