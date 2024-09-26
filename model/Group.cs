using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class Group
    {
        public Guid GroupId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Permission> Permissions { get; set; }
        [JsonIgnore]
        public ICollection<Role> Roles { get; set; }
    }
}