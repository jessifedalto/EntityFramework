public class ChannelManagement
{
    public Guid ChannelManagementId { get; set; } = Guid.NewGuid(); 
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid ChannelRoleId {get; set;}
    public ChannelRole ChannelRole { get; set; }
    public Guid ChannelId { get; set; }
    public Channel Channel { get; set; }
}