using DirectId.Data.Interfaces;
using DirectId.Data.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DirectId.Data.Services
{
    public class AccountService : IAccountService
    {
        public Task<DailyBalances> CalculateDailyBalancesAsync(string payload)
        {
            var account = JsonConvert.DeserializeObject<Brand>(payload);

            return null;
        }
    }
}
