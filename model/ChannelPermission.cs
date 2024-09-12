namespace EntityFramework.Model
{
    public class ChannelPermission
    {
        public Guid ChannelPermissionId { get; set; } = Guid.NewGuid();

        public string ChannelPermissionName { get; set; }
        public ICollection<ChannelRole> ChannelRoles { get; set; }
    }
}