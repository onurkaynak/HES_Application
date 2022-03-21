using Microsoft.AspNetCore.Mvc;

namespace CovidApp
{
    public class ResponseGeneratorHelper : ControllerBase
    {
        public ActionResult ResponseGenerator<T>(BaseResponse<T> incomingResponse)
        {
            switch (incomingResponse.ResponseStatusCodes)
            {
                case ResponseStatusCodes.Success:
                case ResponseStatusCodes.AccountCreateSuccess:
                case ResponseStatusCodes.AccountDeleteSuccess:
                case ResponseStatusCodes.AccountUpdateSuccess:
                case ResponseStatusCodes.AccountUpdatePhoneNumberSuccess:
                case ResponseStatusCodes.AccountChangeIsBlockSuccess:
                case ResponseStatusCodes.AccountChangeVisibilitySuccess:
                    return Ok(incomingResponse);
                
                case ResponseStatusCodes.BadRequest:
                    return BadRequest(incomingResponse);
                case ResponseStatusCodes.NotFound:
                case ResponseStatusCodes.AccountCreateFail:
                case ResponseStatusCodes.AccountDeleteFail:
                case ResponseStatusCodes.AccountUpdateFail:
                case ResponseStatusCodes.AccountUpdatePhoneNumberFail:
                case ResponseStatusCodes.AccountChangeIsBlockFail:
                case ResponseStatusCodes.AccountChangeVisibilityFail:
                    return NotFound(incomingResponse);
                default:
                    return new StatusCodeResult(500);
            }
        }
    }
}