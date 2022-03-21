using Microsoft.EntityFrameworkCore;

namespace CovidApp
{
    public class VaccinationInformationRepository : IVaccinationInformationRepository
    {
        private readonly CovidAppDbContext _context;

        public VaccinationInformationRepository(CovidAppDbContext context)
        {
            this._context = context;
        }

        public async Task<VaccinationInformation> Create(VaccinationInformation vaccination)
        {
            await _context.VaccinationInformations.AddAsync(vaccination);
            await _context.SaveChangesAsync();
            return vaccination;
        }

        public async Task Delete(VaccinationInformation vaccination)
        {
            _context.VaccinationInformations.Remove(vaccination);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VaccinationInformation>> GetAllVaccinationInformation()
        {
            return await (from vaccination in _context.VaccinationInformations
                          select vaccination).ToListAsync();
        }

        public async Task<List<User>> GetUsersByVaccinationInformationName(VaccinationName vaccinationName)
        {
            List<User> users = await (from x in _context.VaccinationInformations
                                where x.VacinationName == vaccinationName
                                select x.User).ToListAsync();

            return users;
        }

        public async Task<List<VaccinationInformation>> GetUserVaccinationInformationsByUserId(int id)
        {
            return await (from x in _context.VaccinationInformations
                          where x.UserId == id
                          select x).ToListAsync();
        }

        public async Task<VaccinationInformation> GetVaccinationInformationById(int id)
        {
            return await (from x in _context.VaccinationInformations
                          where x.Id == id
                          select x).FirstOrDefaultAsync();
        }

        public async Task<VaccinationInformation> Update(VaccinationInformation vaccination)
        {
            _context.VaccinationInformations.Update(vaccination);
            await _context.SaveChangesAsync();
            return vaccination;
        }
    }
}