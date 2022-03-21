namespace CovidApp
{
    public interface IVaccinationInformationRepository
    {
        Task<VaccinationInformation> Create(VaccinationInformation vaccination);
        Task Delete(VaccinationInformation vaccination);
        Task<List<VaccinationInformation>> GetAllVaccinationInformation();
        Task<VaccinationInformation> GetVaccinationInformationById(int id);
        Task<VaccinationInformation> Update(VaccinationInformation vaccination);
        Task<List<User>> GetUsersByVaccinationInformationName(VaccinationName vaccinationName);
        Task<List<VaccinationInformation>> GetUserVaccinationInformationsByUserId(int id);
    }
}