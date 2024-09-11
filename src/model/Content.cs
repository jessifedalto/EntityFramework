public class Content
{
    public Guid ContentId { get; set; } = Guid.NewGuid();
    public byte[] Piece { get; set; }
    public Guid VideoId { get; set; }
    public Video Video { get; set; }
}