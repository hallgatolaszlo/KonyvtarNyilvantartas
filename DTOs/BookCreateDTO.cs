namespace KonyvtarNyilvantartas.DTOs
{
    public class BookCreateDTO
    {
        public required string Title { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; }
    }
}
