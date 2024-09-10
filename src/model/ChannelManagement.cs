public class ChannelManagement
{
    public int ChannelManagementId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int ChannelRoleId {get; set;}
    public ChannelRole ChannelRole { get; set; }
    public int ChannelId { get; set; }
    public Channel Channel { get; set; }
}