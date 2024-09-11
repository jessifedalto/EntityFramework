using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class MyStreamingContext : DbContext
{

    private readonly string _connectionString;

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set;}
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Subscribed> Subscribeds { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<ChannelRole> ChannelRoles { get; set; }
    public DbSet<ChannelPermission> ChannelPermissions { get; set; }
    public DbSet<ChannelManagement> ChannelManagements { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder opt)
    {
        opt.UseSqlServer("Data Source=CT-C-001YN\\SQLEXPRESS;Initial Catalog=EF;Integrated Security=True;TrustServerCertificate=True");
    }

}