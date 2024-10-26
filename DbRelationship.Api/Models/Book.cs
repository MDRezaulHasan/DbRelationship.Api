namespace DbRelationship.Api.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }=String.Empty;
    
    //Joining other table or entity reference: many to one
    public Author Author { get; set; }=default!;
    public int AuthorId { get; set; }
    
    //Collection of publishers
    public ICollection<BookPublisher> BookPublishers { get; set; }
}