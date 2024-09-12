using System.Text.RegularExpressions;

public class Permission 
{
    public Guid PermissionId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public ICollection<Group> Groups { get; set; }
}