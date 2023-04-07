using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dotnet2.Models;

namespace dotnet2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;
        public ProductController(ProductDbContext productDbContext)
        {
             _dbContext = productDbContext;
        }
        

        [HttpGet]

       public ActionResult<IEnumerable<Product>> GetProducts()
      {
        return _dbContext.Products;
      }
      
      [HttpGet("{productId:int}")]

      public async Task<ActionResult<Product>> GetById(int productId){
         var product  = await _dbContext.Products.FindAsync(productId);
         return product;
      }

      [HttpPost]

      public async Task<ActionResult> Create(Product product){
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return Ok();
      }


      [HttpPut]

      public async Task<ActionResult> Update(Product product)
      {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
        return Ok();
      }

      [HttpDelete("{productId:int}")]

      public async Task<ActionResult> Delete(int productId){
        var product = await _dbContext.Products.FindAsync(productId);
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
        return Ok();
      }
       
    }
}