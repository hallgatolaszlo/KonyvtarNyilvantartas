namespace KonyvtarNyilvantartas.DTOs
{
    public class AuthorCreateDTO
    {
        public required string Name { get; set; }
        public DateTime? BirthDate { get; set; } = null;
    }
}
