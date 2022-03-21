namespace CovidApp
{
    public class VaccinationInformationService : IVaccinationInformationService
    {
        private readonly IVaccinationInformationRepository _vaccinationInformationRepository;

        public VaccinationInformationService(IVaccinationInformationRepository vaccinationInformationRepository)
        {
            this._vaccinationInformationRepository = vaccinationInformationRepository;
        }

        public async Task<VaccinationInformation> Create(VaccinationInformation vaccination)
        {
            var vacc = await _vaccinationInformationRepository.GetVaccinationInformationById(vaccination.Id);

            if (vacc == null)
                return await _vaccinationInformationRepository .Create(vaccination);

            throw new Exception("Girilen aşı zaten mevcut");
        }

        public async Task Delete(int id)
        {
            var vaccination = await _vaccinationInformationRepository.GetVaccinationInformationById(id);

            if (vaccination != null)
                await _vaccinationInformationRepository.Delete(vaccination);

            throw new Exception("Girilen Id aşı bulunamadı");
        }

        public async Task<List<VaccinationInformation>> GetAllVaccinationInformation()
        {
            var vaccinationList = await _vaccinationInformationRepository.GetAllVaccinationInformation();

            if (vaccinationList != null)
                return vaccinationList;

            throw new Exception("Aşı bilgisi bulunamadı");
        }

        public async Task<List<User>> GetUsersByVaccinationInformationName(VaccinationName vaccinationName)
        {
            var users = await _vaccinationInformationRepository.GetUsersByVaccinationInformationName(vaccinationName);

            if (users != null)
                return users;

            throw new Exception("Girilen aşıdan hiç kişi bulunamadı");
        }

        public async Task<List<VaccinationInformation>> GetUserVaccinationInformationsByUserId(int id)
        {
            var usersVaccInfo = await _vaccinationInformationRepository.GetUserVaccinationInformationsByUserId(id);

            if (usersVaccInfo != null)
                return usersVaccInfo;

            throw new Exception("Girilen kişi ile ilgili aşı bulunamadı");
        }

        public async Task<VaccinationInformation> GetVaccinationInformationById(int id)
        {
            var vaccination = await _vaccinationInformationRepository.GetVaccinationInformationById(id);

            if (vaccination != null)
                return vaccination;

            throw new Exception("Girilen id ile aşı bilgisi bulunamadı");
        }

        public async Task<VaccinationInformation> Update(int id, VaccinationInformation vaccination)
        {
            var updatedVaccination = await _vaccinationInformationRepository.GetVaccinationInformationById(id);

            if (updatedVaccination != null)
            {
                updatedVaccination.VacinationName = vaccination.VacinationName;
                updatedVaccination.VaccinationDate = vaccination.VaccinationDate;
                updatedVaccination.UserId = vaccination.UserId;
                updatedVaccination.User = vaccination.User;

                await _vaccinationInformationRepository.Update(updatedVaccination);
            }

            throw new Exception("Güncellencek aşı id'si geçersiz");
        }
    }

}