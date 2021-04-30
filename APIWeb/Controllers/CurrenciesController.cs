using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWeb.Models;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Shapes;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIWeb.Controllers

{
    public class CurrenciesController : ApiController
    {
        // GET: api/Currencys
        public async Task<IHttpActionResult> GetCurrencysAsync()
        {
            try
            {
                var resultado = new List<CurrencyTodosModel>(); // Resultado que se va a devolver
                string txtRatio = "currency_base;currency_quote;ratio" + "\n"; //Cabecera del txt 

                dynamic currenciesFrom = new List<currencyModel>(); //Lista Currency FROM 
                dynamic currenciesTo = new List<currencyModel>(); //Lista Currency TO

                using (var HttpClient = new HttpClient())
                {
                    string url = "https://api.mercadolibre.com";
                    HttpClient.BaseAddress = new Uri(url);
                    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpClient.DefaultRequestHeaders.Clear();

                    string ApiURLcurrencies = String.Format("/currencies/");

                    //Obtengo respuesta del Endpoint Currencies
                    var responseCurrencies = await HttpClient.GetAsync(ApiURLcurrencies);

                    //verifico el estado de la Endpoint Currencies
                    if (responseCurrencies.IsSuccessStatusCode)
                    {
                        var result = responseCurrencies.Content.ReadAsStringAsync().Result;
                        currenciesFrom = JsonConvert.DeserializeObject(result); // Currencies FROM 
                        currenciesTo = JsonConvert.DeserializeObject(result); // Currencies TO 

                        //Recorro FROM y TO para obtener todas las Currency_conversions posibles, teniendo en cuenta la respuesta del servidor remoto
                        foreach (var currencyFrom in currenciesFrom)
                        {
                            CurrencyTodosModel currencyTodos = new CurrencyTodosModel(); // Instancio el resultado de un FROM
                            currencyTodos.todolar = new List<CurrencyConversionModel>(); // Instancio la conversion de FROM con todas las TO posible
                            foreach (var currencyTo in currenciesTo)
                            {
                                //URL del Endpoint  currency_conversions con los parametros FROM id y TO id
                                var ApiURLcurrency_conversions = String.Format("/currency_conversions/search?from={0}&to={1}", currencyFrom.id, currencyTo.id);

                                //Obtengo respuesta del Endpoint Currency Conversions
                                var responseCurrency_conversions = await HttpClient.GetAsync(ApiURLcurrency_conversions);

                                //verifico el estado del Endpoint Currency Conversions
                                if (responseCurrency_conversions.IsSuccessStatusCode)
                                {
                                    var resultCurrency_conversions = responseCurrency_conversions.Content.ReadAsStringAsync().Result;
                                    dynamic jsonCurrency_conversions = JsonConvert.DeserializeObject<CurrencyConversionModel>(resultCurrency_conversions);

                                    //Generando el txt
                                    txtRatio = txtRatio + jsonCurrency_conversions.currency_base + ";" +
                                                          jsonCurrency_conversions.currency_quote + ";" +
                                                          jsonCurrency_conversions.ratio + "\n";

                                    currencyTodos.todolar.Add(jsonCurrency_conversions);

                                    //return Ok(resultCurrency_conversions);
                                }
                            }
                            //Guardamos la cabecera de FROM
                            currencyTodos.id = currencyFrom.id;
                            currencyTodos.symbol = currencyFrom.symbol;
                            currencyTodos.description = currencyFrom.description;
                            currencyTodos.decimal_places = currencyFrom.decimal_places;
                            
                            resultado.Add(currencyTodos);
                        }
                    }
                }
                
                // Guardar Datos 
                string PathJson = @"D:\resultados.json";
                string PathCsv =  @"D:\ratio.csv";
                File.WriteAllText(PathJson, resultado.ToString());
                File.WriteAllText(PathCsv, txtRatio);

                return Ok(resultado);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}


