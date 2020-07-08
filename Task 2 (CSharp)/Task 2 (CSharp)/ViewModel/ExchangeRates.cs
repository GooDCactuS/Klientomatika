using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Task_2__CSharp_.Models;

namespace Task_2__CSharp_.ViewModel
{
    public class ExchangeRates
    {
        public Currency Dollar { get; set; }
        public Currency Euro { get; set; }

        public ExchangeRates()
        {
            Dollar = new Currency {Name="Доллар США", RateInRubles = 0.01m};
            Euro = new Currency{Name="Евро", RateInRubles = 0.01m};
        }


        public async Task UpdateRatesAsync()
        {
            var rates = await CbrParser.GetRates();

            Dollar.RateInRubles = rates["Доллар США"];
            Euro.RateInRubles = rates["Евро"];
        }
    }
}