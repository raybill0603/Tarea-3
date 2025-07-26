using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class RoomRepository : IRoomRepository {
    private readonly DesignerContext _context;

    public RoomRepository(DesignerContext context) {
        _context = context;
    }

    public async Task<List<Room>> ObtenerTodosAsync() => await _context.Rooms.ToListAsync();

    public async Task<Room> ObtenerPorIdAsync(int id) => await _context.Rooms.FindAsync(id);

    public async Task AgregarAsync(Room room) {
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Room room) {
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id) {
        var room = await _context.Rooms.FindAsync(id);
        if (room != null) {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
