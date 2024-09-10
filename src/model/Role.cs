public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public ICollection<Group> Groups { get; set; }
    public ICollection<User> Users { get; set; }
}