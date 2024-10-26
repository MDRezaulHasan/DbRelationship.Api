namespace DbRelationship.Api.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    
    //Joining other table or entity reference: one to one
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }= default!;
    
    //Joining other table or entity reference: one to many
    public ICollection<Book> Books { get; set; }= default!;

}