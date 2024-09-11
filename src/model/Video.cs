public class Video
{
    public Guid VideoId { get; set; } = Guid.NewGuid();
    public string VideoName { get; set;}
    public Guid ChannelId { get; set; }
    public Channel Channel { get; set; }
    public ICollection<Playlist> Playlists { get; set; }
    public ICollection<Content> Contents { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Reaction> Reactions { get; set; }
}