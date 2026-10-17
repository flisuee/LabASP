namespace LabApp.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Isbn { get; set; } = "";
    public DateTime? PublicationDate { get; set; } // gravity.db: publication_date
    public int NumPages { get; set; } // gravity.db: num_pages
    public decimal Price { get; set; }

    public string Author { get; set; } = "";
}