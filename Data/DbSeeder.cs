namespace Wijha.Data;

public class DbSeeder
{
    private readonly AppDbContext _db;

    public DbSeeder(AppDbContext db)
    {
        _db = db;
    }

    public void Run()
    {
    }
}
