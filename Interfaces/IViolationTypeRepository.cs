namespace CovidApp
{
    public interface IViolationTypeRepository
    {
        Task<IEnumerable<ViolationType>> GetAllViolationType();
        Task<ViolationType> GetViolationTypeById(int id);
        Task<ViolationType> CreateViolationType(ViolationType violationType);
        Task<ViolationType> UpdateViolationTypeById(ViolationType violationType);
        Task<ViolationType> DeleteViolationTypeById(int id);
    }
    
}