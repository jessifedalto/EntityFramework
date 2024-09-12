public class Subscribed
{
    public Guid SubscribedId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid ChannelId { get; set; }
    public Channel Channel { get; set; }
}