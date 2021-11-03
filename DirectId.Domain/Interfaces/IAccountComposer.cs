using DirectId.Data.Models;
using System.Threading.Tasks;

namespace DirectId.Data.Interfaces
{
    public interface IAccountComposer
    {
        Task<DailyBalancesResult> CalculateDailyBalancesAsync(string payload);
    }
}
