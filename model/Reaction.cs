public class Reaction
{
    public Guid ReactionId { get; set; } = Guid.NewGuid();
    public ReactionType ReactionType { get; set; }
    public Guid VideoId { get; set; }
    public Video Video { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}