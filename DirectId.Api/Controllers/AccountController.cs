using DirectId.Api.Models;
using DirectId.Api.Utils;
using DirectId.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DirectId.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountComposer accountComposer;

        public AccountController(IAccountComposer accountComposer)
        {
            this.accountComposer = accountComposer;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateDailyBalanceAsync([FromBody] AccountRequest accountRequest)
        {
            var result = await accountComposer.CalculateDailyBalancesAsync(accountRequest.AccountId);

            return Ok(result);
        }
    }
}
