public class Content
{
    public int ContentId { get; set; }
    public byte[] Piece { get; set; }
    public int VideoId { get; set; }
    public Video Video { get; set; }
}