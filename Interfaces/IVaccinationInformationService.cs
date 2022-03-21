namespace CovidApp
{
    public interface IVaccinationInformationService
    {
        Task<VaccinationInformation> Create(VaccinationInformation vaccination);
        Task Delete(int id);
        Task<List<VaccinationInformation>> GetAllVaccinationInformation();
        Task<VaccinationInformation> GetVaccinationInformationById(int id);
        Task<VaccinationInformation> Update(int id, VaccinationInformation vaccination);
        Task<List<User>> GetUsersByVaccinationInformationName(VaccinationName vaccinationName);
        Task<List<VaccinationInformation>> GetUserVaccinationInformationsByUserId(int id);
    }
    
}