using Microsoft.AspNetCore.Mvc;

namespace CovidApp
{
    [ApiController]
    [Route("[controller]")]
    public class VaccinationInformationController : ControllerBase
    {
        private readonly IVaccinationInformationService _vaccinationService;

        public VaccinationInformationController(IVaccinationInformationService vaccinationService)
        {
            this._vaccinationService = vaccinationService;

        }

        [HttpGet]
        public async Task<List<VaccinationInformation>> GetVaccinationsInformations()
        {
            return await _vaccinationService.GetAllVaccinationInformation();

        }

        [HttpGet("{id}")]
        public async Task<VaccinationInformation> GetVaccinaitonInformationById(int id)
        {
            return await _vaccinationService.GetVaccinationInformationById(id);
        }

        [HttpPost]
        public async Task<VaccinationInformation> CreateVaccinationInformation(VaccinationInformation vaccination)
        {
            return await _vaccinationService.Create(vaccination);
        }

        [HttpPut("{id}")]
        public async Task<VaccinationInformation> UpdateNotifyById(int id, VaccinationInformation vaccination)
        {
            return await _vaccinationService.Update(id, vaccination);
        }

        [HttpDelete("{id}")]
        public async void DeleteAddress(int id)
        {
            await _vaccinationService.Delete(id);
        }
    }
}