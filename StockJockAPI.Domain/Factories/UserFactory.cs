using StockJockAPI.Domain.Models;

namespace StockJockAPI.Domain.Factories
{
    public class UserFactory
    {
        public User Create()
        {
            return new User();
        }
    }
}