namespace CovidApp
{
    public interface INotifyRepository
    {
        Task<IEnumerable<Notify>> GetAllNotifies();
        Task<Notify> GetNotifyById(int id);
        Task<Notify> GetNotifyByViolationTypeId(int violationTypeId);
        Task<IEnumerable<Notify>> GetNotifiesByAddressId(int addressId);
        Task<IEnumerable<Notify>> GetNotifiesByCityId(int cityId);
        Task<IEnumerable<Notify>> GetNotifiesByDistrictId(int districtId);
        Task<IEnumerable<Notify>> GetNotifiesByUserId(int userId);
        Task<IEnumerable<Notify>> GetNotifiesByViolationSubject(ViolationSubject violationSubject);
        Task<Notify> CreateNotify(Notify notify);
        Task<Notify> UpdateNotifyById(Notify notify);
        Task<Notify> DeleteNotifyById(int id);
        
    }

}