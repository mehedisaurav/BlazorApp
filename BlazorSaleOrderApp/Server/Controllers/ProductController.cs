using BlazorSaleOrderApp.Server.AppDbContext;
using BlazorSaleOrderApp.Shared.Dto.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorSaleOrderApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly BlazorAppDbContext _context;

        public ProductController(BlazorAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<ICollection<ProductDto>> Get()
        {
            return Ok(_context.Products.Select(x => new ProductDto
            {
                Name = x.Name,
                Id = x.Id,
                Price = x.Price,
                Quantity = x.Quantity,
            }));
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id) 
        {
            if (id == 0)
            {
                return new ProductDto();
            }
            else
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return null;
                }
                return new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity
                };
            }
        }
    }
}
