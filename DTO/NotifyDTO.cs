
namespace CovidApp
{
    [Serializable]
    public class NotifyDTO
    {
        public string? Title { get; set; }
        public ViolationSubject? ViolationSubject { get; set; }
        public ViolationType? ViolationType { get; set; }
        public string? ViolationDetail { get; set; }
        
        public NotifyDTO()
        {

        }
        public NotifyDTO(Notify notify)
        {
            this.Title=Title;
            this.ViolationSubject=ViolationSubject;
            this.ViolationType=ViolationType;
            this.ViolationDetail=ViolationDetail;
        }
    }

}