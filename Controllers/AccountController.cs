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
        [HttpGet("suspendable/{id}")]
        public async Task<bool> IsAccountSuspended([FromRoute(Name = "id")] string id)
        {
            return await _service.IsAccountSuspended(id);
        }
        [HttpPost]
        [Route("login")]
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
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] dynamic requestBody)
        {
            string name = requestBody.Name;
            string password = requestBody.Password;
            string email = requestBody.Email;
            string phone = requestBody.Phone;
            string role = requestBody.Role;
            if (await _service.Register(name, password, email, phone, role))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAccount([FromBody] dynamic requestBody)
        {
            if (await _service.UpdateAccount(requestBody))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("suspend/{id}")]
        public async Task<IActionResult> SuspendAccount([FromBody] dynamic requestBody)
        {
            string accountId = requestBody.id;
            DateTime due = requestBody.due;
            if (await _service.Suspend(accountId, due))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
