public class Reaction
{
    public int ReactionId { get; set; }
    public ReactionType ReactionType { get; set; }
    public int VideoId { get; set; }
    public Video Video { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}