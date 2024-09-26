using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public UserRole UserRole { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        [JsonIgnore]
        public ICollection<Channel> Channels { get; set; }
        [JsonIgnore]
        public ICollection<Playlist> Playlists { get; set; }
        [JsonIgnore]
        public ICollection<Reaction> Reactions { get; set; }
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
        [JsonIgnore]
        public ICollection<Subscribed> Subscribes { get; set; }
        [JsonIgnore]
        public ICollection<ChannelManagement> ChannelManagements { get; set; }
    }
}