public class Video
{
    public int VideoId { get; set; }
    public string VideoName { get; set;}
    public int ChannelId { get; set; }
    public Channel Channel { get; set; }
    public ICollection<Playlist> Playlists { get; set; }
    public ICollection<Content> Contents { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Reaction> Reactions { get; set; }
}