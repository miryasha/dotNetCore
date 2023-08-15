
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>

{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;
    public virtual DbSet<Book> Books { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07320CCA7D");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0706056ECC");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAB05484F9").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User", 
                NormalizedName = "USER", 
                Id = "78713bd4-00af-4a34-97f7-c2953203208b"
            }, 
            new IdentityRole
            {
                Name = "Administrator", 
                NormalizedName = "ADMINISTRATOR",
                Id = "207d3c67-4914-4cc7-8e18-00d4c786adc5"
            }
            );


        var hasher = new PasswordHasher<ApiUser>();
        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
               Id = "f42d0bcc-b2f7-4900-a4c1-3507976f9166", 
               Email = "admin@bookstore.com", 
               NormalizedEmail = "ADMIN@BOOKSTORE.COM",
               UserName = "admin@bookstore.com",
               NormalizedUserName = "ADMIN@BOOKSTORE.COM",
               FirstName = "Systerm", 
               LastName = "Admin", 
               PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApiUser
            {
                Id = "906a695a-cf80-4320-8ca0-ee1c12270618",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "Systerm",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }
            );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "78713bd4-00af-4a34-97f7-c2953203208b", 
                UserId = "906a695a-cf80-4320-8ca0-ee1c12270618",
            },
            new IdentityUserRole<string>
            {
                RoleId = "207d3c67-4914-4cc7-8e18-00d4c786adc5",
                UserId = "f42d0bcc-b2f7-4900-a4c1-3507976f9166",
            }

            );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
