using Microsoft.AspNetCore.Mvc;
using P5AspEntity.Data;
using P5AspEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace P5AspEntity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduitsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProduitsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduits()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduit(int id)
        {
            var produit = await _context.Products.FindAsync(id);

            if (produit == null)
                return NotFound();

            return produit;
        }

      
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduit(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduit), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduit(int id, Product input)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            product.Name = input.Name;
            product.Price = input.Price;

            await _context.SaveChangesAsync();

            return NoContent();
        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}