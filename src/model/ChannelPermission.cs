public class ChannelPermission
{
    public Guid ChannelPermissionId { get; set; } = Guid.NewGuid();
    public ICollection<ChannelRole> ChannelRoles { get; set; }
}