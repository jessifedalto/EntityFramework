using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class ChannelPermission
    {
        public Guid ChannelPermissionId { get; set; } = Guid.NewGuid();

        public string ChannelPermissionName { get; set; }
        [JsonIgnore]
        public ICollection<ChannelRole> ChannelRoles { get; set; }
    }
}