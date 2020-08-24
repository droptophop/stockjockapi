using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockJockAPI.Domain.Factories;
using StockJockAPI.Domain.Models;

namespace StockJockAPI.Controllers
{
    [Route("api/iex")]
    [ApiController]
    public class IEXContorller : ControllerBase
    {
        public IEXContorller()
        {
            _stockFactory = new StockFactory();
        }
        
        private readonly StockFactory _stockFactory;

        [HttpGet]
        public async Task<ActionResult> GetAllStockSymbols()
        {
            ApiHelper.InitializeClient();

            List<StockSymbol> symbols = await _stockFactory.LoadSymbols();

            return Ok(symbols);
        }

        [Route("{symbol}")]
        [HttpGet]
        public async Task<ActionResult> GetStockQuote(string symbol)
        {
            ApiHelper.InitializeClient();
            
            Stock stockQuote = await _stockFactory.LoadStock(symbol);

            return Ok(stockQuote);
        }
    }
}