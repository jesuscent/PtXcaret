using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PtXcaret.Business.IBussinnes;
using PtXcaret.Models;
using PtXcaret.Services.IBussinnes;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PtXcaret.Business.Businnes
{
    public class BusEntries : IBusEntries
    {
       
        private string URL;
        private readonly ILogger<BusEntries> _logger;
        private readonly IServiceEntries _serviceEntries;

        public BusEntries(ILogger<BusEntries> logger, IServiceEntries serviceEntries)
        {                     
            _logger = logger;
            _serviceEntries = serviceEntries;

        }

        public async Task<Entries> GetAllEntriesByHtpps(bool https)
        {
            var entries = new Entries();
            try
            {
                _logger.LogInformation("Consultando los registros por el filtro https");

                var data = await _serviceEntries.GetAllEntries(); 
                var result = data.entries.Where(x => x.HTTPS == https);
                entries.Count = result.Count();
                entries.entries = result.ToList();
                return entries;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error no se pudo obtener los registros: {ex}");
                return entries;
            }
           
        }

        public async Task<Categories> GetAllCategoryEntries()
        {
            var categories = new Categories();
            try
            {
                _logger.LogInformation("Consultando los registros por categorías");

                var data = await _serviceEntries.GetAllEntries();
                var result = data.entries.Select(x => x.Category).Distinct().ToList();
                categories.count = result.Count();
                categories.categories = result.ToList();
                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error no se pudo obtener los registros por categorías: {ex}");
                return categories;
            }
           
        }

    }
}
