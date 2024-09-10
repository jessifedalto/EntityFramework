using System.Text.RegularExpressions;

public class Permission 
{
    public int PermissionId { get; set; }
    public string Name { get; set; }
    public ICollection<Group> Groups { get; set; }
}