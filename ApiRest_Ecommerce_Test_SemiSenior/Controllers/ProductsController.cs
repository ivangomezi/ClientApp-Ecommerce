using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest_Ecommerce_Test_SemiSenior.Models;
using ApiRest_Ecommerce_Test_SemiSenior.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest_Ecommerce_Test_SemiSenior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _productsRepository;
        public ProductsController(ProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(ProductsRepository));
        }


        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAll()
        {
            var response = await _productsRepository.GetAll();
            if (response == null)
            {
                List<Products> dt = new List<Products>();
                Products dt_ = new Products();
                dt.Add(dt_);
                return dt;
            }
            return response;
        }

        
        [HttpGet("{products}")]
        public async Task<ActionResult<Products>> GetId(int products)
        {
            var response = await _productsRepository.GetId(products);
            if (response == null)
            {
                Products dt_ = new Products();
                return dt_;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Products>> Post([FromBody] Products products)
        {
            var result = await _productsRepository.Post(products);
            Products obj = new Products();
            obj = result;
            return obj;
        }

        [HttpPut]
        public async Task<ActionResult<Products>> Put([FromBody] Products products)
        {
            var result = await _productsRepository.Put(products);
            Products obj = new Products();
            obj = result;
            return obj;
        }

        [HttpDelete("{products}")]
        public async Task<ActionResult<Products>> Delete(int products)
        {
            var result = await  _productsRepository.Delete(products);
            return result;
        }
    }
}
