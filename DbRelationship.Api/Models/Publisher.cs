namespace DbRelationship.Api.Models;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    
    //Joining other table or entity reference: one to one
    public int AuthorId { get; set; }
    public Author Author { get; set; }= default!;
    
    //Collection of publishers
    public ICollection<BookPublisher> BookPublishers { get; set; }
}