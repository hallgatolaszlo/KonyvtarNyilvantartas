using KonyvtarNyilvantartas.Models;
using Microsoft.EntityFrameworkCore;

namespace KonyvtarNyilvantartas.Data
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
    }
}
