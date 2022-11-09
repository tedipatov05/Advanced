using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Market
{
    internal class Stock
    {
        //полета (характеристики)
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        private decimal marketCapitalization;

        //get и set
        public string CompanyName { get => companyName; set => companyName = value; }
        public string Director { get => director; set => director = value; }
        public decimal PricePerShare { get => pricePerShare; set => pricePerShare = value; }
        public int TotalNumberOfShares { get => totalNumberOfShares; set => totalNumberOfShares = value; }
        public decimal MarketCapitalization { get => pricePerShare * totalNumberOfShares; set => marketCapitalization = value; }

        //constructor
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = pricePerShare * totalNumberOfShares;
        }

        //ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine("Company: " + CompanyName)
                .AppendLine("Director: " + Director)
                .AppendLine("Price per share: $" + PricePerShare)
                .AppendLine("Market capitalization: $" + MarketCapitalization);

            return sb.ToString();
        }
    }
}
