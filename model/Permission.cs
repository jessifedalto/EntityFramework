using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class Permission
    {
        public Guid PermissionId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Group> Groups { get; set; }
    }
}