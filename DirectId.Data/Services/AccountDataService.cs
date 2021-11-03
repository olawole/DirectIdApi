using DirectId.Data.Interfaces;
using DirectId.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace DirectId.Data.Services
{
    public class AccountDataService : IAccountDataService
    {
        private readonly Brand brand;
        public AccountDataService()
        {
            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string jsonData = File.ReadAllText("Account.json");
            brand = JsonConvert.DeserializeObject<Brand>(jsonData);
        }

        public async Task<IList<Account>> GetAllAsync()
        {
            return await Task.FromResult(brand.Accounts);
        }

        public async Task<Account> GetByIdAsync(string accountId)
        {
            return await Task.FromResult(brand.Accounts.FirstOrDefault(x => x.AccountId == accountId));
        }
    }
}
