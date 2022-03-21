using CovidApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class NotifyController : ControllerBase
{
    private INotifyService _notifyService;

    public NotifyController(INotifyService notifyService)
    {
        _notifyService= notifyService;
    }

    [HttpGet]
    public async Task<IEnumerable<NotifyDTO>> GetAllNotifies()
    {
        return await _notifyService.GetAllNotifies();
    }

    [HttpGet("{id}")]
    public async Task<NotifyDTO> GetNotifyById(int id)
    {
        return await _notifyService.GetNotifyById(id);
    }

    [HttpGet("violationid")]
    public async Task<NotifyDTO> GetNotifyByViolationTypeId(int violationTypeId)
    {
        return await _notifyService.GetNotifyByViolationTypeId(violationTypeId);
    }
    [HttpGet("addressid")]
    public async Task<IEnumerable<NotifyDTO>> GetNotifiesByAddressId(int addressId)
    {
        return await _notifyService.GetNotifiesByAddressId(addressId);
    }

    [HttpGet("cityid")]
    public async Task<IEnumerable<NotifyDTO>> GetNotifiesByCityId(int cityId)
    {
        return await _notifyService.GetNotifiesByCityId(cityId);
    }
    [HttpGet("districtid")]
    public async Task<IEnumerable<NotifyDTO>> GetNotifiesByDistrictId(int districtId)
    {
        return await _notifyService.GetNotifiesByDistrictId(districtId);
    }

    [HttpGet("userid")]
    public async Task<IEnumerable<NotifyDTO>> GetNotifiesByUserId(int userId)
    {
        return await _notifyService.GetNotifiesByUserId(userId);
    }

    [HttpGet("violationsubject")]
    public async Task<IEnumerable<NotifyDTO>> GetNotifiesByViolationSubject(ViolationSubject violationSubject)
    {
        return await _notifyService.GetNotifiesByViolationSubject(violationSubject);
    }

    [HttpPost]
    public async Task<NotifyDTO> CreateNotify(Notify notify)
    {
        return await _notifyService.CreateNotify(notify);
    }

    [HttpPut("{id}")]
    public async Task<NotifyDTO> UpdateNotifyById(Notify notify)
    {
        return await _notifyService.UpdateNotifyById(notify);
    }

    [HttpDelete("{id}")]
    public async Task<NotifyDTO> DeleteNotifyById(int id)
    {
        return await _notifyService.DeleteNotifyById(id);
    }
    
}
