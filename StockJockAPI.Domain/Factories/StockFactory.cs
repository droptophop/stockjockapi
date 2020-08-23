using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StockJockAPI.Domain.Models;

namespace StockJockAPI.Domain.Factories
{
    public class StockFactory
    {
        public async Task<StockSymbol> FindStock(string name, string symbol)
        {
            List<StockSymbol> stockList = await LoadSymbols();

            StockSymbol stockSymbol = new StockSymbol();

            foreach (StockSymbol stockItem in stockList)
            {
                if(stockItem.Name == name || stockItem.Symbol == symbol)
                {
                    stockSymbol = stockItem;
                }
            }
            
            return stockSymbol; 
        }

        public async Task<Stock> LoadStock() //Default method for testing. Obselete for implementation.
        {
            string url = "https://cloud.iexapis.com/stable/stock/msft/quote?token=pk_47017819d55f4fa387ee42458b6a4dd5&symbols=msft";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Stock stock = await response.Content.ReadAsAsync<Stock>();

                    return stock;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Stock> LoadStock(string stocksymbol) //Method with argument for specific symbol.
        {
            string url = "https://cloud.iexapis.com/stable/stock/" + stocksymbol + "/quote?token=pk_47017819d55f4fa387ee42458b6a4dd5&symbols=" + stocksymbol;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Stock stock = await response.Content.ReadAsAsync<Stock>();

                    return stock;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<StockSymbol>> LoadSymbols() // Retrieves an array of all stock symbols from IEX api
        {
            string url = "https://cloud.iexapis.com/stable/ref-data/symbols?token=pk_47017819d55f4fa387ee42458b6a4dd5";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    JArray stockList = await response.Content.ReadAsAsync<JArray>();

                    List<StockSymbol> newStockList = stockList.ToObject<List<StockSymbol>>();

                    return newStockList;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}