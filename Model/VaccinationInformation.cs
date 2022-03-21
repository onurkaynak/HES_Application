namespace CovidApp
{
    public class VaccinationInformation
    {
        public int Id { get; set; }
        public VaccinationName VacinationName { get; set; }
        public DateOnly VaccinationDate { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}