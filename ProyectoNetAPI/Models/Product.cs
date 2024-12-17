namespace ProyectoNetApi.Models;

public class Product
{
  public int Id { get; set; }
  public required String Name { get; set; }

  public required String Description { get; set; }

  public Double Price { get; set; }

  public int Stock { get; set; }

  //public Category? category { get; set; }

}