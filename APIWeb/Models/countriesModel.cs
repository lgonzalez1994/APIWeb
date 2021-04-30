using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWeb.Models
{
    public class countriesModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public string currency_id { get; set; }
    }
}