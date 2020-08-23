using System.ComponentModel.DataAnnotations.Schema;

namespace StockJockAPI.Domain.Models
{
    public class Stock
    {
        public int Id {get; set;}
		public string CompanyName {get; set;}

		public string Symbol {get; set;}

		public decimal LatestPrice {get; set;}

		public decimal Change {get; set;}

		public double ChangePercent {get; set;}

		public int Quantity {get; set;} //To be used if we implement Stock Trading Game feature. 

		[ForeignKey("UserId")] //This might not be even necessary. Gotta love Azure SQL DB not telling us that UserId is a foreign key.
		public User Userid {get; set;}

		public Stock() 
		{

		}
    }
}