namespace ShareTheLoad.Domain.Entities;

public class Product : Base
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; } = 0m;
}