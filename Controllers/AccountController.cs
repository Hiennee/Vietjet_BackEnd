using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Vietjet_BackEnd.DTO;
using Vietjet_BackEnd.Models;
using Vietjet_BackEnd.Services;

namespace Vietjet_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly AccountService _service;
        public AccountController(AccountService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ICollection<AccountDTO>> GetAccounts()
        {
            return await _service.GetAccounts();
        }
        [HttpGet("{id}")]
        public async Task<AccountDTO> GetAccount([FromRoute(Name = "id")] string id)
        {
            return await _service.GetAccount(id);
        }
        [HttpGet("/suspendable/{id}")]
        public async Task<bool> IsAccountSuspended([FromRoute(Name = "id")] string id)
        {
            return await _service.IsAccountSuspended(id);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] dynamic requestBody)
        {
            string email = requestBody.Email;
            string password = requestBody.Password;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email and Password could not be null");
            }
            var account = await _service.Login(email, password);
            if (account == null)
            {
                return BadRequest("Invalid email or password");
            }
            return Ok(account);
        }
    }
}
