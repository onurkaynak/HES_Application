using System.Buffers;
using Microsoft.AspNetCore.Mvc;

namespace CovidApp
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private ResponseGeneratorHelper ResponseGeneratorHelper;

        public UserController(IUserService userService)
        {
            _userService = userService;
            ResponseGeneratorHelper = new ResponseGeneratorHelper();
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResponse<User>>> Create(User user)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.Create(user));
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResponse<User>>> Update(User user)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.Update(user));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<string>>> Delete(User user)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.Delete(user));
        }

        [HttpGet("getall")]
        public async Task<ActionResult<BaseResponse<List<User>>>> GetAll()
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<User>>> FindById([FromQuery]int id)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.FindById(id));
        }

        [HttpGet("positivecount")]
        public async Task<ActionResult<BaseResponse<int>>> PositiveCount()
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.CoronaCount());
        }

        [HttpGet("positivecountbycity")]
        public async Task<ActionResult<BaseResponse<int>>> PositiveCountByCity([FromQuery]int plateCode)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.CoronaCountByCity(plateCode));
        }

        [HttpGet("getallbycity")]
        public async Task<ActionResult<BaseResponse<List<User>>>> GetAllByCity([FromQuery]int plateCode)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.GetAllUserByCityFromPlateCode(plateCode));
        }

        [HttpGet("getallpositives")]
        public async Task<ActionResult<BaseResponse<List<User>>>> GetAllPositiveUser()
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.GetAllByIsCorona(true));
        }

        [HttpGet("getallpositivesbycity")]
        public async Task<ActionResult<BaseResponse<List<User>>>> GetAllPositiveUserByCityPlateCode([FromQuery]int plateCode)
        {
            return ResponseGeneratorHelper.ResponseGenerator(await _userService.GetAllByCityPlateCodeAndIsCorona(plateCode,true));
        }
    }
}