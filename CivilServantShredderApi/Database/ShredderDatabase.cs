using Adminbereich.Models;
using Microsoft.EntityFrameworkCore;

namespace CivilServantShredderApi.Database;

public class ShredderDatabase : DbContext
{
    public ShredderDatabase(DbContextOptions options) : base(options)
    {

    }

    public DbSet<BP_Poll> BP_Polls { get; set; }
    public DbSet<BP_TextAndPicture> BP_TextAndPictures { get; set; }
    public DbSet<BP_TextOnly> BP_TextOnlys { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BP_Poll>(builder =>
        {
            builder.HasKey(s => s.Id);
            builder.OwnsMany(x => x.PollSelections, build => { build.ToJson(); });

        });

        modelBuilder.Entity<BP_TextAndPicture>(builder =>
        {
            builder.HasKey(s => s.Id);
        });

        modelBuilder.Entity<BP_TextOnly>(builder =>
        {
            builder.HasKey(s => s.Id);
        });
    }
}
