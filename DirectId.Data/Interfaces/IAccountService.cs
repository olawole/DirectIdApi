using DirectId.Data.Models;
using System.Threading.Tasks;

namespace DirectId.Data.Interfaces
{
    public interface IAccountService
    {
        Task<DailyBalances> CalculateDailyBalancesAsync(string payload);
    }
}
