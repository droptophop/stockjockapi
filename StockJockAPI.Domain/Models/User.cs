using System.Collections.Generic;
using StockJockAPI.Domain.Models;

namespace StockJockAPI.Domain
{
    public class User
    {
        public int Id {get; set;}
		public string Username {get; set;}

		public string Password {get; set;}

		public List<Stock> Stocks {get; set;}

		public decimal Balance {get; set;} //To be used if we implement Stock Trading Game feature.

		public User()
		{
			Stocks = new List<Stock>();
		}

		public void AddStock(Stock stock)
		{
			if(!(Stocks.Exists(s => s.Symbol == stock.Symbol))) //If doesn't exist, add stock to list.
			{
				Stocks.Add(stock);
			}
		}

		public void RemoveStock(Stock stock)
		{
			if(Stocks.Exists(s => s.Symbol == stock.Symbol)) //If does exist, remove stock from list.
			{
				var StockToRemove = Stocks.Find(s => s.Symbol == stock.Symbol);
				Stocks.Remove(StockToRemove);
			}
		}
    }
}