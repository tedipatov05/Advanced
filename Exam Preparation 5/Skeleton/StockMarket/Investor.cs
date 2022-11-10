using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace StockMarket
{
    public class Investor
    {
        public Investor( string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new HashSet<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public HashSet<Stock> Portfolio { get; set; }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if(stock.MarketCapitalization > 10000 && stock.PricePerShare <= MoneyToInvest)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Any(s => s.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }
            Stock stock = Portfolio.FirstOrDefault(s => s.CompanyName == companyName);
            if(stock.PricePerShare > sellPrice )
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                Portfolio.Remove(stock);
                MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName)
        => Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

        public Stock FindBiggestCompany()
        {
            decimal biggestMarketCapitalization = decimal.MinValue;
            Stock biggestStock = null;
            foreach(Stock stock in Portfolio)
            {
                if(stock.MarketCapitalization > biggestMarketCapitalization)
                {
                    biggestMarketCapitalization = stock.MarketCapitalization;
                    biggestStock = stock;
                }
            }
            return biggestStock;
        }
        public string InvestorInformation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach(Stock stock in Portfolio)
            {
                stringBuilder.AppendLine(stock.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
