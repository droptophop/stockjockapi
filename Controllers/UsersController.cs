using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockJockAPI.Domain.Factories;
using StockJockAPI.Domain.Models;
using StockJockAPI.Storing;
using StockJockAPI.Storing.Repositories;

namespace StockJockAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        public UsersController(IUserRepo repo)
        {
            _stockFactory = new StockFactory();
            _userFactory = new UserFactory();
            _repo = repo;
        }
        

        private readonly StockFactory _stockFactory;
        private readonly UserFactory _userFactory;
        private readonly IUserRepo _repo;

        [HttpGet]
        public ActionResult <List<User>> GetAllUsers()
        {
            var userRepo = _repo;

            return userRepo.GetAllUsers();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult <User> GetUserById(int id)
        {
            var userRepo = _repo;

            return userRepo.GetUserById(id);
        }

        [HttpPost]
        public ActionResult AddUser(string username, string password)
        {
            var userRepo = _repo;

            userRepo.AddUser(username, password);

            return Ok(StatusCode(201));
        }
    }
}