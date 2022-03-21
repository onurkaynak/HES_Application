namespace CovidApp
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public Gender Gender { get; set; }
        public bool IsCorona { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Passport>? Passports { get; set; }
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; } 
        public virtual ICollection<Notify>? Notifies { get; set; }   
        public ICollection<VaccinationInformation>? VaccinationInformation { get; set; } 
        public int CityId { get; set; }
        public virtual City? City { get; set; }   
    }
}