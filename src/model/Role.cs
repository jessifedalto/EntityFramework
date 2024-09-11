public class Role
{
    public Guid RoleId { get; set; } = Guid.NewGuid();
    public string RoleName { get; set; }
    public ICollection<Group> Groups { get; set; }
    public ICollection<User> Users { get; set; }
}