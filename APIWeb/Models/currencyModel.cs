using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWeb.Models
{
    //Modelo que devuelve https://api.mercadolibre.com/currencies/
    public class currencyModel
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public int decimal_places { get; set; }

    }

    //Modelo que devuelve https://api.mercadolibre.com/currency_conversions/search?from=ARS&to=USD
    public class CurrencyConversionModel
    {
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
        public double ratio { get; set; }
        public double rate { get; set; }
        public double inv_rate { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime valid_until { get; set; }
    }

    //Modelo de la api solicitada
    public class CurrencyTodosModel
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public int decimal_places { get; set; }
        public List<CurrencyConversionModel> todolar { get; set;}


    }

}