namespace EntityFramework.Model
{
    public class Comment
    {
        public Guid CommentId { get; set; } = Guid.NewGuid();
        public string CommentText { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid VideoId { get; set; }
        public Video Video { get; set; }
    }
}