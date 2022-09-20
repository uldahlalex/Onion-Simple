
namespace Application.DTOs;

public class PostProductDTO
{
    public int Price { get; set; }
    public string Name { get; set; }
}

public class PartialUpdateProductDTO
{
    public int? Price { get; set; }
    public string? Name { get; set; }
    public int Id { get; set; }
}