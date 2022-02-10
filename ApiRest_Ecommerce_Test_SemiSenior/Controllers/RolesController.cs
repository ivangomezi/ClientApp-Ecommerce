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
    public class RolesController : ControllerBase
    {
        private readonly RolesRepository _rolesRepository;
        public RolesController(RolesRepository rolesRepository)
        {
            this._rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(RolesRepository));
        }

        // GETALL api/
        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<Roles>>> GetAll()
        {
            var response = await _rolesRepository.GetAll();
            if (response == null)
            {
                List<Roles> dt = new List<Roles>();
                Roles dt_ = new Roles();
                dt.Add(dt_);
                return dt;
            }
            return response;
        }
    }
}
