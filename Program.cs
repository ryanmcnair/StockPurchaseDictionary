using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("GME", "Gamestop");
            stocks.Add("AMC", "AMC Entertainment");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
            purchases.Add((ticker: "GM", shares: 150, price: 23.21));
            purchases.Add((ticker: "CAT", shares: 20, price: 3.51));
            purchases.Add((ticker: "GME", shares: 1000, price: 8.75));
            purchases.Add((ticker: "AMC", shares: 10, price: 221.15));
            purchases.Add((ticker: "GME", shares: 15, price: 22.80));
            purchases.Add((ticker: "GM", shares: 10, price: 221.15));

            string GM = stocks["GM"];
            string CAT = stocks["CAT"];
            string GME = stocks["GME"];
            string AMC = stocks["AMC"];

            Dictionary<string, double> ownershipReport = new Dictionary<string, double>();
            

            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                // Does the company name key already exist in the report dictionary?
                // If it does, update the total valuation
                // If not, add the new key and set its value
                if (ownershipReport.ContainsKey(stocks[purchase.ticker]))
                {
                    var newValuation = ownershipReport[stocks[purchase.ticker]] + purchase.shares * purchase.price;
                    ownershipReport[stocks[purchase.ticker]] = newValuation;
                }
                else
                {
                    var addToValuation = purchase.shares * purchase.price;
                    ownershipReport.Add(stocks[purchase.ticker], addToValuation);
                }

                foreach (var (key, value) in ownershipReport)
                {
                    Console.WriteLine($"{key}: {value}");
                }
            }
        }
    }
}
