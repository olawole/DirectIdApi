using DirectId.Data.Interfaces;
using DirectId.Data.Models;
using DirectId.Domain.Composers;
using Moq;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DirectId.Domain.Tests.Unit
{
    public class AccountComposerTests
    {
        private readonly Mock<IAccountDataService> mockAccountDataService;

        public AccountComposerTests()
        {
            mockAccountDataService = new Mock<IAccountDataService>();
        }
        [Fact]
        public async Task AccountComposerTests_CalculateDailyBalancesAsync_Ok()
        {
            mockAccountDataService.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(GetAccountData);
            var accountComposer = new AccountComposer(mockAccountDataService.Object);

            var result = await accountComposer.CalculateDailyBalancesAsync("1234556");

            Assert.Equal(500, result.EndOfDayBalances[0].Balance);
            Assert.Equal(495, result.EndOfDayBalances[1].Balance);
            Assert.Equal(576, result.EndOfDayBalances[2].Balance);
        }

        [Fact]
        public async Task AccountComposerTests_CalculateDailyBalancesAsync_NotFound()
        {
            mockAccountDataService.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(default(Account));

            var accountComposer = new AccountComposer(mockAccountDataService.Object);

            var result = await accountComposer.CalculateDailyBalancesAsync("1234556");

            Assert.Null(result);

        }

        private Account GetAccountData()
        {
            string jsonData = File.ReadAllText("TestAccount.json");
            var brand = JsonConvert.DeserializeObject<Brand>(jsonData);
            return brand.Accounts[0];
        }
    }
}
