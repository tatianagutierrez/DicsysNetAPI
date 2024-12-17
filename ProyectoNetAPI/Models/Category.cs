namespace ProyectoNetApi.Models;

public class Category
{
  public int Id { get; set; }
  public required String Name { get; set; }

  public virtual required ICollection<Product> Products { get; set; }
}