using System;
using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
//using APIWeb.Models;
using Newtonsoft.Json;
//using APIWeb.Filters;
//using System.Net.Http.Formatting;

namespace APIWeb.Controllers
{
    public class PaisesController : ApiController
    {
        private webapiEntities db = new webapiEntities();

        //Web API REST 
        private String Baseurl = "https://api.mercadolibre.com";
        private String Api = "/classified_locations/countries/";        

        // GET: api/Pais
        public IHttpActionResult GetPaises()
        {
            dynamic resultado = new List<object>();
         
            string url = Baseurl + Api;
            try
            {
                var json = new WebClient().DownloadString(url);
                dynamic resultadoAux = JsonConvert.DeserializeObject(json);

                foreach (dynamic country in resultadoAux)
                {
                    if (country.id != "BR" && country.id != "CO")
                    {
                        resultado.Add(country);
                    }
                }

                return Ok(resultado);
            }
            catch
            {
                return InternalServerError();
            }
        }



        // GET: api/Pais/5
        //[ResponseType(typeof(Pais))]
        public IHttpActionResult GetPais(string id)
        {
            dynamic resultado = new List<object>();
            try
            {

                //URL Country
                string urlCountry = Baseurl + Api;
                var json = new WebClient().DownloadString(urlCountry);
                dynamic countryCheck = JsonConvert.DeserializeObject(json); //Verificar si existe el ID ingresado con los IDs de ML
                var band = 0;
                string ids = " ";
                foreach (var c in countryCheck)
                {
                    if (c.id == id)
                        band = 1;
                    ids = ids + c.id + "  ";
                }

                if (band == 1)
                {
                    //URL Country/ID
                    string url = Baseurl + Api + id;

                    json = new WebClient().DownloadString(url);
                    dynamic pais = JsonConvert.DeserializeObject(json);

                    if (pais.id == "BR" || pais.id == "CO") // Si el pais es id=3=BR o id=6=CO
                    {
                        return Unauthorized();
                    }

                    return Ok(pais);
                }
                else
                {
                    return BadRequest("El id ingresado no es valido No es valido, IDs Validos: " + ids);
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}