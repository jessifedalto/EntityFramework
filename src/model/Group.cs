public class Group
{
    public int GroupId { get; set; }
    public string Name { get; set; }
    public ICollection<Permission> Permissions { get; set; }
    public ICollection<Role> Roles { get; set; }
}