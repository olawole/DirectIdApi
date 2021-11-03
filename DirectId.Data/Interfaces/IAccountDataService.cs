using DirectId.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectId.Data.Interfaces
{
    public interface IAccountDataService
    {
        Task<IList<Account>> GetAllAsync();

        Task<Account> GetByIdAsync(string accountId);
    }
}
