using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CovidApp
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CovidAppDbContext _context;
        public AddressRepository(CovidAppDbContext context)
        {
            _context = context;
        }
        public async Task<City> CreateCity(City city)
        {
            await _context.Set<City>().AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<District> CreateDistrict(District district)
        {
            await _context.Set<District>().AddAsync(district);
            await _context.SaveChangesAsync();
            return district;
        }

        public async Task<Address> DeleteAddress(int id)
        {
            var DeleteAddress = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            _context.Addresses.Remove(DeleteAddress);
            _context.SaveChangesAsync();
            return null;

        }



        public async Task<City> FindCityByName(string CityName)
        {
            return await _context.Set<City>().FirstOrDefaultAsync(c => c.Name == CityName);
        }

        public async Task<District> FindDistrictByName(string DistirctName)
        {
            return await _context.Set<District>().FirstOrDefaultAsync(c => c.Name == DistirctName);
        }

        public async Task<Address> GetAddressById(int id)
        {
            var getAddress = await _context.Set<Address>().SingleOrDefaultAsync(p => p.Id == id);
            if (getAddress != null)
            {
                return getAddress;
            }
            return null;
        }

        public async Task<List<Address>> GetAllAddress()
        {
            return await _context.Set<Address>().ToListAsync();
        }

        public async Task<List<City>> GetAllCity()
        {
            return await _context.Set<City>().ToListAsync();
        }

        public async Task<List<District>> GetAllDistricts()
        {
            return await _context.Set<District>().ToListAsync();

        }

    public async Task<Address> CreateAddress(Address address)
    {
        _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address> UpdateAddress(Address address)
    {
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
        return address;
    }
}

}