using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Stock_Market
{
    internal class Investor
    {
        //полета (характеристики)
        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        //getters and setters
        public List<Stock> Portfolio { get => portfolio; set => portfolio = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public decimal MoneyToInvest { get => moneyToInvest; set => moneyToInvest = value; }
        public string BrokerName { get => brokerName; set => brokerName = value; }

        //constructor
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        //methods
        public int Count
        {
            get => this.portfolio.Count;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && moneyToInvest >= stock.PricePerShare)
            {
                this.portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (Stock stock in this.portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    //намирам дадената стока
                    //не мога да я продам: продажната цена < цена за споделяне
                    if (sellPrice < stock.PricePerShare)
                    {
                        return "Cannot sell " + companyName + ".";
                    }
                    else
                    {
                        //продавам
                        this.portfolio.Remove(stock);
                        MoneyToInvest += sellPrice;
                        return companyName + " was sold.";

                    }
                }
            }

            //не намирам такава стока
            return companyName + " does not exist.";
        }

        public Stock FindStock(string companyName)
        {
            foreach (Stock stock in this.portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    return stock;
                }
            }

            return null;
        }

        public Stock FindBiggestCompany()
        {
            if (this.portfolio.Count == 0)
            {
                return null;
            }

            //вариант 1: 
            return this.Portfolio
               .OrderByDescending(x => x.MarketCapitalization)
               .FirstOrDefault();



            //вариант 2:
            /*Stock maxStock = null;
            decimal maxValue = 0; //най-големия market capitalization
            foreach(Stock stock in this.portfolio)
            {
                if (stock.MarketCapitalization > maxValue)
                {
                    maxValue = stock.MarketCapitalization;
                    maxStock = stock;
                }
            }
 
            return maxStock;*/
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (Stock stock in this.portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString();
        }
    }
}
