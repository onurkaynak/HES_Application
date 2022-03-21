namespace CovidApp
{
    using Microsoft.EntityFrameworkCore;
    public class ViolationTypeRepository : IViolationTypeRepository
    {
        private readonly CovidAppDbContext _dbcontext;
        public ViolationTypeRepository(CovidAppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        async Task<ViolationType> IViolationTypeRepository.CreateViolationType(ViolationType violationType)
        {
            _dbcontext.ViolationTypes.Attach(violationType).State = EntityState.Added;
            await _dbcontext.SaveChangesAsync();
            return violationType;
        }

        async Task<ViolationType> IViolationTypeRepository.DeleteViolationTypeById(int id)
        {
            ViolationType violationType = await _dbcontext.ViolationTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (violationType != null)
            {
                _dbcontext.ViolationTypes.Remove(violationType);
                await _dbcontext.SaveChangesAsync();
            }
            return null;
        }

        async Task<IEnumerable<ViolationType>> IViolationTypeRepository.GetAllViolationType()
        {
            List<ViolationType> temp = await (from ac in _dbcontext.ViolationTypes select ac).ToListAsync();
            return temp;
        }

        async Task<ViolationType> IViolationTypeRepository.GetViolationTypeById(int id)
        {
            ViolationType violationType = await _dbcontext.ViolationTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (violationType != null)
            {
                return violationType;
            }
            return null;
        }

        async Task<ViolationType> IViolationTypeRepository.UpdateViolationTypeById(ViolationType violationType)
        {
            ViolationType ViolationType = await _dbcontext.ViolationTypes.SingleOrDefaultAsync(x => x.Id == violationType.Id);
            if (ViolationType != null)
            {
                ViolationType.IsMaskedUsed = violationType.IsMaskedUsed;
                ViolationType.IsHygienic = violationType.IsHygienic;
                ViolationType.IsSocialDistanceViolated = violationType.IsSocialDistanceViolated;
                await _dbcontext.SaveChangesAsync();
                return ViolationType;
            }
            return null;
        }
    }

}