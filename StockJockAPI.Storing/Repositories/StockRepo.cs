using System.Linq;
using System.Collections.Generic;
using StockJockAPI.Domain.Models;
using StockJockAPI.Storing.Repositories;

namespace StockJockAPI.Storing
{
    public class StockRepo
    {
        private DataBaseContext _db;

        public StockRepo(DataBaseContext db)
        {
            _db = db;
        }

        public void AddStock(User user, Stock stock)
		{
			UserRepo ur = new UserRepo(_db);
			var newUser = ur.LoginUser(user.Username, user.Password);
			
			if(newUser != null)
			{
				newUser.AddStock(stock);
				_db.Users.Update(newUser);
				_db.SaveChanges();
			}
		}

		public void RemoveStock(User user, Stock stock)
		{
			UserRepo ur = new UserRepo(_db);
			var newUser = ur.LoginUser(user.Username, user.Password);

			if(newUser != null)
			{
				// newUser.RemoveStock(stock);
				// _db.Users.Update(newUser);     
				// Only remove reference, does not remove data entry.

				var StockForRemoval = _db.Stocks.FirstOrDefault(s => s.Symbol == stock.Symbol && s.Userid.Id == user.Id);
				_db.Stocks.Remove(StockForRemoval);
				_db.SaveChanges();
			}
		}
    }
}