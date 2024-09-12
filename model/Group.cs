namespace EntityFramework.Model
{
    public class Group
    {
        public Guid GroupId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}