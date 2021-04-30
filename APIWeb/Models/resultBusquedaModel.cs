using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWeb.Models
{
    public class resultBusquedaModel
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string permalink { get; set; }
        public int seller_id { get; set; }
        public string seller_permalink { get; set; }


    }
    public class BusquedaModel
    {
        public string site_id { get; set; }
        public string query { get; set; }
        public Paging paging { get; set; }
        public List<object> results { get; set; }
        public List<object> secondary_results { get; set; }
        public List<object> related_results { get; set; }
        public Sort sort { get; set; }
        public List<AvailableSort> available_sorts { get; set; }
        public List<object> filters { get; set; }
        public List<AvailableFilter> available_filters { get; set; }

        
    }
}