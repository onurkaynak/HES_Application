namespace CovidApp
{
    public interface INotifyService
    {
        Task<IEnumerable<NotifyDTO>> GetAllNotifies();
        Task<NotifyDTO> GetNotifyById(int id);
        Task<NotifyDTO> GetNotifyByViolationTypeId(int violationTypeId);
        Task<IEnumerable<NotifyDTO>> GetNotifiesByAddressId(int addressId);
        Task<IEnumerable<NotifyDTO>> GetNotifiesByCityId(int cityId);
        Task<IEnumerable<NotifyDTO>> GetNotifiesByDistrictId(int districtId);
        Task<IEnumerable<NotifyDTO>> GetNotifiesByUserId(int userId);
        Task<IEnumerable<NotifyDTO>> GetNotifiesByViolationSubject(ViolationSubject violationSubject);
        Task<NotifyDTO> CreateNotify(Notify notify);
        Task<NotifyDTO> UpdateNotifyById(Notify notify);
        Task<NotifyDTO> DeleteNotifyById(int id);

            // VIOLATION TYPE
        Task<IEnumerable<ViolationType>> GetAllViolationType();
        Task<ViolationType> GetViolationTypeById(int id);
        Task<ViolationType> CreateViolationType(ViolationType violationType);
        Task<ViolationType> UpdateViolationTypeById(ViolationType violationType);
        Task<ViolationType> DeleteViolationTypeById(int id);
        
    }
    
}