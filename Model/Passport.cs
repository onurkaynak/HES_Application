namespace CovidApp
{
    public class Passport
    {
        public int Id { get; set; }
        public string? No { get; set; }
        public CountryCode CountryCode { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}