using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PtXcaret.Business.IBussinnes;
using System.Threading.Tasks;
using System;
using PtXcaret.Models;

namespace PtXcaret.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly ILogger<EntriesController> _logger;
        private readonly IBusEntries _busEntries;

        public EntriesController(ILogger<EntriesController> logger,IBusEntries busEntries)
        {
                _logger= logger;
            _busEntries= busEntries;
        }
        /// <summary>
        /// Método que se utiliza obtener un listado de entries por el filtro de htpps  
        /// </summary>
        /// <param name="https"></param>
        /// <returns>Entries</returns>
        [HttpGet]
        [Route("GetAllEntriesByHtpps/{https}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entries))]
        public async Task<ActionResult> GetAllEntriesByHtpps(bool https)
        {
            var response = new Entries();
            try
            {
                response = await _busEntries.GetAllEntriesByHtpps(https);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"No se pudo obtener los registros: {ex}");
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// que se utiliza para obtener un listado de entries por las direfente categoarías 
        /// </summary>
        /// <returns>Categories</returns>
        [HttpGet]
        [Route("GetAllCategoryEntries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categories))]
        public async Task<ActionResult> GetAllCategoryEntries()
        {
            var response = new Categories();
            try
            {
                response = await _busEntries.GetAllCategoryEntries();
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"No se pudo obtener los registros: {ex}");
               
            }
            return Ok(response);
        }


    }
}
