namespace KonyvtarNyilvantartas.DTOs
{
    public class BookReadDTO
    {
        public string Title { get; set; } = null!;
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; } = null!;
    }
}
