using Microsoft.EntityFrameworkCore;

namespace CovidApp
{
    public class UserRepository : IUserRepository
    {
        private readonly CovidAppDbContext _context;
        public UserRepository(CovidAppDbContext context)
        {
            _context = context;
        }
        public async Task Create(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u=>u.Id==id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllUserByCityFromPlateCode(int plateCode)
        {
            return await _context.Users.Where(u=>u.City.PlateCode==plateCode).ToListAsync();
        }

        public async Task<List<User>> GetAllByCityPlateCodeAndIsCorona(int plateCode, bool isCorona)
        {
            return await _context.Users.Where(u=>u.City.PlateCode==plateCode && u.IsCorona==isCorona).ToListAsync();
        }

        public async Task<List<User>> GetAllByIsCorona(bool isCorona)
        {
            return await _context.Users.Where(u=>u.IsCorona==isCorona).ToListAsync();
        }

        public async Task Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }

}