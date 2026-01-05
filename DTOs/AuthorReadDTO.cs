using KonyvtarNyilvantartas.Models;

namespace KonyvtarNyilvantartas.DTOs
{
    public class AuthorReadDTO
    {
        public string Name { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public ICollection<BookReadDTO>? Books { get; set; }
    }
}
