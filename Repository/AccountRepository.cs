using Microsoft.EntityFrameworkCore;

namespace CovidApp
{
    public class AccountRepository:IAccountRepository
    {
        private readonly CovidAppDbContext _context;
        public AccountRepository(CovidAppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Account account)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> FindByIdAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a=>a.Id==id);
        }

        public Account FindById(int id)
        {
            return _context.Accounts.FirstOrDefault(a=>a.Id==id);
        }

        public async Task<Account> FindByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a=>a.PhoneNumber==phoneNumber);
        }

        public Account FindByPhoneNumber(string phoneNumber)
        {
            return _context.Accounts.FirstOrDefault(a=>a.PhoneNumber==phoneNumber);
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<List<Account>> GetAllByBlocked(bool isBlocked)
        {
            return await _context.Accounts.Where(a=>a.Blocked==isBlocked).ToListAsync();
        }

        public async Task<List<Account>> GetAllByVisibility(bool isVisible)
        {
            return await _context.Accounts.Where(a=>a.IsVisibility==isVisible).ToListAsync();
        }

        public async Task Update(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}