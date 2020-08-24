using System.Collections.Generic;
using System.Linq;
using StockJockAPI.Domain.Models;

namespace StockJockAPI.Storing.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly DataBaseContext _db;

        public UserRepo(DataBaseContext db)
        {
            _db = db;
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            var users = _db.Users;

            return users.ToList();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void AddUser(string username, string password)
        {
            User user = new User();
			user.Username = username;
			user.Password = password;

			_db.Users.Add(user);
			SaveChanges();
        }

        public User LoginUser(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
			if (user == null) //If user does not exist.
			{
				AddUser(username, password);
				var newuser = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
				return newuser;
			}
			else //User exist
			{
				List<Stock> stocks = new List<Stock>();
				stocks = _db.Stocks.Where(s => s.Userid == user).ToList();
				if (stocks != null) //User has stocks .
				{
					user.Stocks = stocks; //Load user stocks.
				}
				return user;
			}
        }
    }
}