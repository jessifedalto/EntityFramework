public class ChannelRole
{
    public string ChannelId { get; set;}
    public ICollection<ChannelPermission> ChannelPermissions { get; set;}
    public ICollection<ChannelManagement> ChannelManagements { get; set;}
}