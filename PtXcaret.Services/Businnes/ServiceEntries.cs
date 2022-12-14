using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PtXcaret.Models;
using PtXcaret.Services.IBussinnes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PtXcaret.Services.Businnes
{
    public class ServiceEntries : IServiceEntries
    {
       
        private string URL;
        private readonly ILogger<ServiceEntries> _logger;
        public ServiceEntries(IConfiguration iConfiguration, ILogger<ServiceEntries> logger)
        {

            URL = iConfiguration.GetSection("UrlPublicapis").Value;
            _logger = logger;
        }

        public async Task<Entries> GetAllEntries()
        {
            var entries = new Entries();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage result = await client.GetAsync(URL + "entries");
                    var JsonResult = result.Content.ReadAsStringAsync().Result;
                    entries = JsonConvert.DeserializeObject<Entries>(JsonResult);
                  
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error al consumir el servicio GetAllEntries: {ex}");               
            }
            return entries;
        }
    }
}
