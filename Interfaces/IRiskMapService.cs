namespace CovidApp
{
    public interface IRiskMapService
    {
        Task<List<RiskDTO>> GetRiskMap();
    }
}