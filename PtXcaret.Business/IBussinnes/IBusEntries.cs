using PtXcaret.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PtXcaret.Business.IBussinnes
{
    public interface IBusEntries
    {   
        /// <summary>
        /// interfaz que se utiliza obtener un listado de entries por el filtro de htpps  
        /// </summary>
        /// <param name="htpps"> parametro que condiciona la consulta del listado de entries </param>
        /// <returns>listado entries</returns>
        Task<Entries> GetAllEntriesByHtpps(bool https);
        /// <summary>
        /// interfaz que se utiliza para obtener un listado de entries por las direfente categoarías 
        /// </summary>
        /// <returns> lista de entries </returns>
        Task<Categories> GetAllCategoryEntries();
    }
}
