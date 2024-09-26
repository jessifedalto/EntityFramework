using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class Playlist
    {
        public Guid PlaylistId { get; set; } = Guid.NewGuid();
        public string PlaylistName { get; set; }
        [JsonIgnore]
        public ICollection<Video> Videos { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}