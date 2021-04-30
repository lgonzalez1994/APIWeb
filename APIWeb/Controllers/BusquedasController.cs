using System;
using System.Collections.Generic;
//using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;
using APIWeb.Models;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Web.Mvc;
using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

namespace APIWeb.Controllers
{
    public class BusquedasController : ApiController
    {
        //Web API REST 
        private string Baseurl = "https://api.mercadolibre.com";
        private string Api = "/sites/MLA/search/?q=";

        // GET: api/busquedas/q=QUERY
        public IHttpActionResult GetBusquedas(String q)
        {
            try
            {

                //URL API Web ML
                string url = Baseurl + Api + q;

                //Obtenemos la consulta desde la Api de ML
                var json = new WebClient().DownloadString(url);
                dynamic dataML = JsonConvert.DeserializeObject<resultMLModel>(json);

                dynamic resultBusquedaArray = new List<object>();

                foreach (var result in dataML.results)
                {
                    resultBusquedaModel resultBusqueda = new resultBusquedaModel();

                    resultBusqueda.id = result.id;
                    resultBusqueda.site_id = result.site_id;
                    resultBusqueda.title = result.title;
                    resultBusqueda.permalink = result.permalink;
                    resultBusqueda.price = result.price;
                    resultBusqueda.seller_id = result.seller.id;
                    resultBusqueda.seller_permalink = result.seller.permalink;

                    resultBusquedaArray.Add(resultBusqueda);

                }
                dataML.results = resultBusquedaArray;

                return Ok(dataML);
            }
            catch
            {
                return InternalServerError();
            }
        }
    } 
}


