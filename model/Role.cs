using System.Text.Json.Serialization;

namespace EntityFramework.Model
{
    public class Role
    {
        public Guid RoleId { get; set; } = Guid.NewGuid();
        public string RoleName { get; set; }
        [JsonIgnore]
        public ICollection<Group> Groups { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}