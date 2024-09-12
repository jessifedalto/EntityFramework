using EntityFramework.Model;

public class ChannelRole
{
    public Guid ChannelRoleId { get; set;} = Guid.NewGuid();
    public ICollection<ChannelPermission> ChannelPermissions { get; set;}
    public ICollection<ChannelManagement> ChannelManagements { get; set;}
}