public class ChannelPermission
{
    public int ChannelPermissionId { get; set; }
    public ICollection<ChannelRole> ChannelRoles { get; set; }
}