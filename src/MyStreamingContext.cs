using Microsoft.EntityFrameworkCore;

public class MyStreamingContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get;}
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Playlist> Playlists { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<User>(user =>
        {
            user.Property(u => u.Name)
            .HasColumnName("Name")
            .HasMaxLength(50)
            .IsRequired();
        });
    }
}