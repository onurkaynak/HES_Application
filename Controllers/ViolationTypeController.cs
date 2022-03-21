
using CovidApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ViolationTypeController : ControllerBase
{
    private INotifyService _notifyService;

    public ViolationTypeController(INotifyService notifyService)
    {
        _notifyService= notifyService;
    }

    [HttpGet]
    public async Task<IEnumerable<ViolationType>> GetAllViolationType()
    {
        return await _notifyService.GetAllViolationType();
    }

    [HttpGet("{id}")]
    public async Task<ViolationType> GetViolationTypeById(int id)
    {
        return await _notifyService.GetViolationTypeById(id);
    }

    [HttpPost]
    public async Task<ViolationType> CreateViolationType(ViolationType violationType)
    {
        return await _notifyService.CreateViolationType(violationType);
    }

    [HttpPut("{id}")]
    public async Task<ViolationType> UpdateViolationTypeById(ViolationType violationType)
    {
        return await _notifyService.UpdateViolationTypeById(violationType);
    }

    [HttpDelete("{id}")]
    public async Task<ViolationType> DeleteViolationTypeById(int id)
    {
        return await _notifyService.DeleteViolationTypeById(id);
    }

}