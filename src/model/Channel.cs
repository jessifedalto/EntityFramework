public class Channel
{
    public int ChannelId { get; set; }
    public string ChannelName { get; set; }
    public ChannelType ChannelType { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Video> Videos { get; set; }
    public ICollection<Subscribed> Subscribes { get; set; }
    public ICollection<ChannelManagement> ChannelManagements { get; set; }
}