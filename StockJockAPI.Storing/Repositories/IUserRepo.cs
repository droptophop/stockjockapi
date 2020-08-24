using System.Collections.Generic;
using StockJockAPI.Domain.Models;

namespace StockJockAPI.Storing.Repositories
{
    public interface IUserRepo
    {
        void SaveChanges();
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(string username, string password);
        User LoginUser(string username, string password);
    }
}