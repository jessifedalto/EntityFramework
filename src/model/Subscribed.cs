public class Subscribed
{
    public int SubscribedId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int ChannelId { get; set; }
    public Channel Channel { get; set; }
}