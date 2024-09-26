using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class Video
    {
        public Guid VideoId { get; set; } = Guid.NewGuid();
        public string VideoName { get; set; }
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }
        [JsonIgnore]
        public ICollection<Playlist> Playlists { get; set; }
        [JsonIgnore]
        public ICollection<Content> Contents { get; set; }
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
        [JsonIgnore]
        public ICollection<Reaction> Reactions { get; set; }
    }
}