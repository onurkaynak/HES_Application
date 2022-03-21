using System.Buffers;
using Microsoft.AspNetCore.Mvc;

namespace CovidApp
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private ResponseGeneratorHelper ResponseGeneratorHelper;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            ResponseGeneratorHelper = new ResponseGeneratorHelper();
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<Account>>> Create(Account account)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.Create(account));
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResponse<Account>>> Update(Account account)
        {   
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.Update(account));
        }

        [HttpPost("updatephonenumber")]
        public async Task<ActionResult<BaseResponse<Account>>> UpdatePhoneNumber(string oldPhoneNumber, string newPhoneNumber)
        {          
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.UpdatePhoneNumber(oldPhoneNumber, newPhoneNumber));
        }

        [HttpPost("changeisblocked")]
        public async Task<ActionResult<BaseResponse<Account>>> ChangeIsBlockedById([FromQuery] int id)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.ChangeIsBlockedById(id));
        }

        [HttpPost("changevisibility")]
        public async Task<ActionResult<BaseResponse<Account>>> ChangeVisibilityById([FromQuery] int id)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.ChangeVisibilityById(id));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<string>>> DeleteById([FromQuery] int id)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.Delete(id));
        }

        [HttpGet("getall")]
        public async Task<ActionResult<BaseResponse<List<Account>>>> GetAll()
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.GetAll());
        }

        [HttpGet("getbyphonenumber")]
        public async Task<ActionResult<BaseResponse<Account>>>  GetByPhoneNumber([FromQuery] string phoneNumber)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.FindByPhoneNumberAsync(phoneNumber));
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<BaseResponse<Account>>>  GetById([FromQuery] int id)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.FindById(id));
        }

        [HttpGet("getallbyblocked")]
        public async Task<ActionResult<BaseResponse<List<Account>>>> GetAllByBlocked([FromQuery] bool isBlocked)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.GetAllByBlocked(isBlocked));
        }

        [HttpGet("getallbyvisibility")]
        public async Task<ActionResult<BaseResponse<List<Account>>>> GetAllByVisibility([FromQuery] bool isVisible)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _accountService.GetAllByVisibility(isVisible));
        }

    }
}