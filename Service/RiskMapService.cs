using System.Linq.Expressions;

namespace CovidApp
{
    public class RiskMapService : IRiskMapService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;

        public RiskMapService(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<List<RiskDTO>> GetRiskMap()
        {
            var cities = _addressRepository.GetAllCity();
            int population = 0;
            int coronaCount = 0;
            double density = 0;
            List<RiskDTO> riskMap = new List<RiskDTO>();

            foreach (var city in cities.Result)
            {
                population =  _userRepository.GetAllUserByCityFromPlateCode(city.PlateCode).Result.Count();
                coronaCount = _userRepository.GetAllByCityPlateCodeAndIsCorona(city.PlateCode,true).Result.Count();
                density = (coronaCount*100)/population;
                riskMap.Add(new RiskDTO{
                    CityName = city.Name,
                    CityPlateCode = city.PlateCode,
                    Density = $"%{density}",
                    Risk = RiskHelper.Calculate(density)
                });
            }
            return riskMap;
        }
    }
}