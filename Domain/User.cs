namespace Domain;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Hash { get; set; }
    public string Salt { get; set; }
    public string Role { get; set; }
}