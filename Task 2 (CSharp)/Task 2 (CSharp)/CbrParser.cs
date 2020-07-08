using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;

namespace Task_2__CSharp_
{
    public class CbrParser
    {
        private static IConfiguration _config;
        private static string _url;

        static CbrParser()
        {
            _config = Configuration.Default.WithDefaultLoader();

            _url = "https://www.cbr.ru/";
        }

        /// <summary>
        /// Returns a dictionary with currency name as key and rate as value.
        /// </summary>
        /// <returns>A dictionary with currency name as key and rate as value.</returns>
        public static async Task<Dictionary<string, decimal>> GetRates()
        {
            var document = await BrowsingContext.New(_config).OpenAsync(_url);

            var tags = document.QuerySelectorAll(@".row.flex-nowrap .indicator_el_value.mono-num");

            var dict = new Dictionary<string, decimal>();


            var dollar = GetDecimalFromString(tags[1].TextContent);
            var euro = GetDecimalFromString(tags[3].TextContent);

            dict.Add("Доллар США", dollar);
            dict.Add("Евро", euro);
            return dict;
        }

        /// <summary>
        /// Returns a decimal version of the number.
        /// </summary>
        /// <param name="number">A number with ',' as separator and currency sign as the last character</param>
        /// <returns>A decimal version of the number.</returns>
        private static decimal GetDecimalFromString(string number)
        {
            number = number.Substring(0, number.Length - 1);

            return new decimal(Math.Round(Double.Parse(number), 2));
        }
    }

}