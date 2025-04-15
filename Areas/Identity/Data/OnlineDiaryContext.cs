using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineDiary.Areas.Identity.Data;
using OnlineDiary.Models;

namespace OnlineDiary.Data;

public class OnlineDiaryContext : IdentityDbContext<OnlineDiaryUser>
{
    public OnlineDiaryContext(DbContextOptions<OnlineDiaryContext> options)
        : base(options)
    {
    }
    public DbSet<MyDiary> MyDiaries { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<MyDiary>()
            .ToTable("MyDiary");
    }
}
