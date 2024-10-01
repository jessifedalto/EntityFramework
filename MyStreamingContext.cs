using EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

public class MyStreamingContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
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
        opt.UseSqlServer("Data Source=CA-C-00651\\SQLEXPRESS;Initial Catalog=EF;Integrated Security=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        #region User

        model.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .OnDelete(DeleteBehavior.NoAction);
        
        model.Entity<User>()
            .HasMany(u => u.Channels)
            .WithMany(c => c.Users);

        model.Entity<User>()
            .HasMany(u => u.Playlists)
            .WithOne(p => p.User);

        model.Entity<User>()
            .HasMany(u => u.Reactions)
            .WithOne(r => r.User);
        
        model.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User);

        model.Entity<User>()
            .HasMany(u => u.Subscribes)
            .WithOne(s => s.User);

        model.Entity<User>()
            .HasMany(u => u.ChannelManagements)
            .WithOne(cm => cm.User);


        #endregion


        #region Video

        model.Entity<Video>()
            .HasOne(v => v.Channel)
            .WithMany(c => c.Videos)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Video>()
            .HasMany(v => v.Playlists)
            .WithMany(p => p.Videos);

        model.Entity<Video>()
            .HasMany(v => v.Contents)
            .WithOne(c => c.Video);

        model.Entity<Video>()
            .HasMany(v => v.Comments)
            .WithOne(c => c.Video);

        model.Entity<Video>()
            .HasMany(v => v.Reactions)
            .WithOne(r => r.Video);

        #endregion


        #region Subscribed

        model.Entity<Subscribed>()
            .HasOne(s => s.User)
            .WithMany(u => u.Subscribes)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Subscribed>()
            .HasOne(s => s.Channel)
            .WithMany(c => c.Subscribes)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region Role

        model.Entity<Role>()
            .HasMany(r => r.Groups)
            .WithMany(g => g.Roles);

        model.Entity<Role>()
            .HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region Reaction

        model.Entity<Reaction>()
            .HasOne(r => r.Video)
            .WithMany(v => v.Reactions)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Reaction>()
            .HasOne(r => r.User)
            .WithMany(v => v.Reactions)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region Playlist

        model.Entity<Playlist>()
            .HasMany(p => p.Videos)
            .WithMany(v => v.Playlists);

        model.Entity<Playlist>()
            .HasOne(p => p.User)
            .WithMany(u => u.Playlists)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region Permission 

        model.Entity<Permission>()
            .HasMany(p => p.Groups)
            .WithMany(g => g.Permissions);

        #endregion

        #region Group

        model.Entity<Group>()
            .HasMany(g => g.Permissions)
            .WithMany(P => P.Groups);

        model.Entity<Group>()
            .HasMany(g => g.Roles)
            .WithMany(r => r.Groups);

        #endregion

        #region Content

        model.Entity<Content>()
            .HasOne(c => c.Video)
            .WithMany(v => v.Contents)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region Comment

        model.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Comment>()
            .HasOne(c => c.Video)
            .WithMany(v => v.Comments)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region ChannelRole

        model.Entity<ChannelRole>()
            .HasMany(cr => cr.ChannelPermissions)
            .WithMany(cp => cp.ChannelRoles);

        model.Entity<ChannelRole>()
            .HasMany(cr => cr.ChannelManagements)
            .WithOne(cm => cm.ChannelRole)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region ChannelPermission

        model.Entity<ChannelPermission>()
            .HasMany(cp => cp.ChannelRoles)
            .WithMany(cr => cr.ChannelPermissions);

        #endregion

        #region ChannelManagement

        model.Entity<ChannelManagement>()
            .HasOne(cm => cm.User)
            .WithMany(u => u.ChannelManagements)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<ChannelManagement>()
            .HasOne(cm => cm.ChannelRole)
            .WithMany(cr => cr.ChannelManagements)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<ChannelManagement>()
            .HasOne(cm => cm.Channel)
            .WithMany(c => c.ChannelManagements)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region Channel

        model.Entity<Channel>()
            .HasMany(c => c.Users)
            .WithMany(u => u.Channels);

        model.Entity<Channel>()
            .HasMany(c => c.Videos)
            .WithOne(v => v.Channel);

        model.Entity<Channel>()
            .HasMany(c => c.Subscribes)
            .WithOne(s => s.Channel);

        model.Entity<Channel>()
            .HasMany(c => c.ChannelManagements)
            .WithOne(cm => cm.Channel);

        #endregion

    }

}