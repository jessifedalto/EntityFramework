public class Playlist
{
    public int PlaylistId { get; set; }
    public string PlaylistName { get; set;}
    public ICollection<Video> Videos { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}