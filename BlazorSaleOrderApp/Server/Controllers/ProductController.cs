using BlazorSaleOrderApp.Server.AppDbContext;
using BlazorSaleOrderApp.Server.Models;
using BlazorSaleOrderApp.Shared.Dto.Common;
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


        [HttpGet("GetProducts")]
        public ActionResult<ICollection<ProductDto>> GetProducts()
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
        public async Task<ProductDto> Get(int? id) 
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

        [HttpPost]
        public async Task<bool> Post(ProductDto product)
        {
            _context.Products.Add(new Product
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            });
            _context.SaveChanges();

            return true;
        }

        [HttpPut]
        public async Task<bool> Put(ProductDto product)
        {
            _context.Products.Update(new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            });
            _context.SaveChanges();

            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            _context.Products.Remove( await _context.Products.FirstOrDefaultAsync(x => x.Id == id)); 
            _context.SaveChanges();
            return true;
        }

        [HttpGet("GetProductSelectList")]
        public async Task<List<SelectModel>> GetProductSelectList()
        {
            return _context.Products.Select(x => new SelectModel
            {
                Id = x.Id,
                Name = x.Name,
                //Price = x.Price,
                //Quantity = x.Quantity
            }).ToList();
        }
    }
}
