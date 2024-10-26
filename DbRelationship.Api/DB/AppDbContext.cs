using DbRelationship.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DbRelationship.Api.DB;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){ }
    
    //Addressing the table or entities in database
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookPublisher> BookPublishers { get; set; }
    
    
    //Db table validation: before hitting database, its mandatory to validate the model or entities 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Validation or check before creating or adding data into database
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.Property(p => p.Name)
                .IsRequired();
            
            //Checking join tables : One to one
            entity.HasOne(o => o.Publisher)
                .WithOne(o => o.Author)
                .HasForeignKey<Publisher>(p => p.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        });
        
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.Property(p => p.Title)
                .IsRequired();
            
            //Checking join tables : Many to one
            entity.HasOne(o => o.Author)
                .WithMany(m=>m.Books)
                .HasForeignKey(fk => fk.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        });
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.Property(p => p.Name)
                .IsRequired();
        });
        
        modelBuilder.Entity<BookPublisher>(entity =>
        {
            //Connecting two tables or entities for establishing:  Many to Many relation
            entity.HasKey(bpk =>new{ bpk.PublisherId,bpk.BookId });

            //Book reference
            entity.HasOne(bp => bp.Book)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.BookId)
                .OnDelete(DeleteBehavior.NoAction);
            
            //Publisher reference
            entity.HasOne(bp => bp.Publisher)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.PublisherId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }

}