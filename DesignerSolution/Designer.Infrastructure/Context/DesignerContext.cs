using Microsoft.EntityFrameworkCore;

public class DesignerContext : DbContext {
    public DesignerContext(DbContextOptions<DesignerContext> options) : base(options) {}

    public DbSet<Room> Rooms { get; set; }
}
