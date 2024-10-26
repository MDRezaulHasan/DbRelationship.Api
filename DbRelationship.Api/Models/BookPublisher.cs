namespace DbRelationship.Api.Models;

public class BookPublisher
{
    // Many to many relationship
    // One book can be published by many publisher
    public Book Book { get; set; }
    public int BookId { get; set; }

    // One publisher can publish many books
    public Publisher Publisher { get; set; }
    public int PublisherId { get; set; }

    
}