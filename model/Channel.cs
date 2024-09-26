using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class Channel
    {
        public Guid ChannelId { get; set; } = Guid.NewGuid();
        public string ChannelName { get; set; }
        public ChannelType ChannelType { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
        [JsonIgnore]
        public ICollection<Video> Videos { get; set; }
        [JsonIgnore]
        public ICollection<Subscribed> Subscribes { get; set; }
        [JsonIgnore]
        public ICollection<ChannelManagement> ChannelManagements { get; set; }
    }
}