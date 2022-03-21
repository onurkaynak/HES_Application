namespace CovidApp
{
    using Microsoft.EntityFrameworkCore;

    public class NotifyRepository : INotifyRepository
    {
        private readonly CovidAppDbContext _dbcontext;
        public NotifyRepository(CovidAppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        async Task<Notify> INotifyRepository.CreateNotify(Notify notify)
        {
            _dbcontext.Notifies.Attach(notify).State = EntityState.Added;
            await _dbcontext.SaveChangesAsync();
            return notify;
        }

        async Task<Notify> INotifyRepository.DeleteNotifyById(int id)
        {
            Notify notify = await _dbcontext.Notifies.SingleOrDefaultAsync(x => x.Id == id);
            if (notify != null)
            {
                _dbcontext.Notifies.Remove(notify);
                await _dbcontext.SaveChangesAsync();
            }
            return null;
        }

        async Task<IEnumerable<Notify>> INotifyRepository.GetAllNotifies()
        {
            List<Notify> temp = await (from ac in _dbcontext.Notifies select ac).ToListAsync();
            return temp;
        }

        async Task<IEnumerable<Notify>> INotifyRepository.GetNotifiesByAddressId(int addressId)
        {
            List<Notify> notifies = await (from us in _dbcontext.Notifies
                                           where us.Address.Id == addressId
                                           select us).ToListAsync();
            return notifies;
        }

        async Task<IEnumerable<Notify>> INotifyRepository.GetNotifiesByCityId(int cityId)
        {
            List<Notify> notifies = await (from us in _dbcontext.Notifies
                                           where us.Address.CityId == cityId
                                           select us).ToListAsync();
            return notifies;
        }

        async Task<IEnumerable<Notify>> INotifyRepository.GetNotifiesByDistrictId(int districtId)
        {
            List<Notify> notifies = await (from us in _dbcontext.Notifies
                                           where us.Address.DistrictId == districtId
                                           select us).ToListAsync();
            return notifies;
        }

        async Task<IEnumerable<Notify>> INotifyRepository.GetNotifiesByUserId(int userId)
        {
            List<Notify> notifies = await (from us in _dbcontext.Notifies
                                           where us.UserId == userId
                                           select us).ToListAsync();
            return notifies;
        }

        async Task<IEnumerable<Notify>> INotifyRepository.GetNotifiesByViolationSubject(ViolationSubject violationSubject)
        {
            List<Notify> notifies = await (from us in _dbcontext.Notifies
                                           where us.ViolationSubject == violationSubject
                                           select us).ToListAsync();
            return notifies;
        }

        async Task<Notify> INotifyRepository.GetNotifyById(int id)
        {
            Notify notify = await _dbcontext.Notifies.SingleOrDefaultAsync(x => x.Id == id);
            if (notify != null)
            {
                return notify;
            }
            return null;
        }

        async Task<Notify> INotifyRepository.GetNotifyByViolationTypeId(int violationTypeId)
        {
            Notify notify = await _dbcontext.Notifies.SingleOrDefaultAsync(x => x.ViolationType.Id == violationTypeId);
            if (notify != null)
            {
                return notify;
            }
            return null;
        }

        async Task<Notify> INotifyRepository.UpdateNotifyById(Notify notify)
        {
            Notify Notify = await _dbcontext.Notifies.SingleOrDefaultAsync(x => x.Id == notify.Id);
            if (notify != null)
            {
                Notify = notify;
                await _dbcontext.SaveChangesAsync();
                return Notify;
            }
            return null;
        }

    }

}