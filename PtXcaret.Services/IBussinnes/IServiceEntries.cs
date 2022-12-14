using PtXcaret.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PtXcaret.Services.IBussinnes
{
    public interface IServiceEntries
    {
        Task<Entries> GetAllEntries();
    }
}
