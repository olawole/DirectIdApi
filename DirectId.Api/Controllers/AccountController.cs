using DirectId.Api.Utils;
using DirectId.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectId.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateDailyBalanceAsync(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("No file was uploaded");
            }

            if (file.ContentType != "application/json")
            {
                return BadRequest("Invalid file type, please upload a json document");
            }

            var data = await file.ReadFileAsync();

            var result = await accountService.CalculateDailyBalancesAsync(data);

            return Ok();
        }
    }
}
