using Microsoft.Identity.Client;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set;}
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public UserRole Role { get; set; }
}