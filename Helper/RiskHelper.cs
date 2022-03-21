namespace CovidApp
{
    public static class RiskHelper
    {
        public static string Calculate(double density)
        {
            switch (density)
            {
                case <= 5:
                    return "Low (BLUE)";
                
                case <= 15:
                    return "Medium (YELLOW)";

                case <= 40:
                    return "High (ORANGE)";

                default:
                    return "Very High (RED)";
            }
        }
    }
}