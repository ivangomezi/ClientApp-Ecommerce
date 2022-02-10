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
    public class BuysController : ControllerBase
    {
        private readonly BuysRepository _buysRepository;
        public BuysController(BuysRepository buysRepository)
        {
            this._buysRepository = buysRepository ?? throw new ArgumentNullException(nameof(BuysRepository));
        }

        [HttpPost]
        public async Task<ActionResult<Buys>> Post([FromBody] Buys buys)
        {
            var result = await _buysRepository.Post(buys);
            return result;
        }
    }
}
