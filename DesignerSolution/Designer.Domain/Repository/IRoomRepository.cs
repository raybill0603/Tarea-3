using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRoomRepository {
    Task<List<Room>> ObtenerTodosAsync();
    Task<Room> ObtenerPorIdAsync(int id);
    Task AgregarAsync(Room room);
    Task ActualizarAsync(Room room);
    Task EliminarAsync(int id);
}
