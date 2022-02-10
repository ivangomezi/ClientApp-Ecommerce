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
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            this._usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(UsersRepository));
        }


        [HttpGet("{user}/{pass}")]
        public async Task<ActionResult<Users>> Get(string user, string pass)
        {
            var response = await _usersRepository.Get(user, pass);
            if (response == null) 
            {
                Users dt = new Users();
                return dt;
            }
            return response;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<Users>>> GetAll()
        {
            var response = await _usersRepository.GetAll();
            if (response == null)
            {
                List<Users> dt = new List<Users>();
                Users dt_ = new Users();
                dt.Add(dt_);
                return dt;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Users>> Post([FromBody] Users users)
        {
            var result = await _usersRepository.Post(users);
            return result;
        }
    }
}
