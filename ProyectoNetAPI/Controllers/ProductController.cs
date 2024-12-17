using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNetApi.Data;
using ProyectoNetApi.Models;

namespace ProyectoNetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ApplicationDbContext context) : ControllerBase
{
  private readonly ApplicationDbContext _context = context;

  [HttpGet]
  public async Task<ActionResult<List<Product>>> GetProducts()
  {
    return Ok(await _context.Product.ToListAsync());
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<Product>> GetProductById(int id)
  {
    var product = await _context.Product.FindAsync(id);

    if (product is null)
      return NotFound();

    return Ok(product);
  }

  [HttpPost]
  public async Task<ActionResult<Product>> AddProduct(Product newProduct)
  {
    if (newProduct is null)
      return BadRequest();

    _context.Product.Add(newProduct);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
  {
    var product = await _context.Product.FindAsync(id);
    if (product is null)
      return NotFound();

    product.Name = updatedProduct.Name;
    product.Description = updatedProduct.Description;
    product.Price = updatedProduct.Price;
    product.Stock = updatedProduct.Stock;
    //TODO: Update Category

    await _context.SaveChangesAsync();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(int id)
  {
    var product = await _context.Product.FindAsync(id);
    if (product is null)
      return NotFound();

    _context.Product.Remove(product);
    await _context.SaveChangesAsync();

    return NoContent();
  }
}