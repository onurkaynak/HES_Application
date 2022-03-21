using System.Buffers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CovidApp
{
    [ApiController]
    [Route("[controller]")]
    public class RiskMapController : ControllerBase
    {
        private readonly IRiskMapService _riskMapService;

        public RiskMapController(IRiskMapService riskMapService)
        {
            _riskMapService = riskMapService;
        }

        [HttpGet]
        public Task<List<RiskDTO>> RiskMap()
        {
            return _riskMapService.GetRiskMap();
        }
    }
}