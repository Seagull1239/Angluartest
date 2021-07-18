using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Angluartest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] ProdName = new[]
        {
            "Potato", "Oreo", "Chillies", "Keyboard", "Nandos Hot Sauce"
        };


        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Products> Get()
        {
            int count = 0;
            int[] Prices = { 2, 6, 10, 200, 30 };
            int[] Stocks = { 30, 23, 2, 45, 90 };
            return Enumerable.Range(1, 5).Select(index => new Products
            {
                ProductId = count + 1,
                Name = ProdName[count],
                Price = Prices[count],
                Stock = Stocks[count++],
            })
            .ToArray();
        }
    }
}
