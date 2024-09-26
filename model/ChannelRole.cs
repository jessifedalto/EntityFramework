using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class ChannelRole
    {
        public Guid ChannelRoleId { get; set; } = Guid.NewGuid();
        [JsonIgnore]
        public ICollection<ChannelPermission> ChannelPermissions { get; set; }
        public ICollection<ChannelManagement> ChannelManagements { get; set; }
    }
}