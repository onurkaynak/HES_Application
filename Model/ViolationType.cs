namespace CovidApp
{
    public class ViolationType
    {
        public int Id { get; set; }
        public bool IsMaskedUsed { get; set; }
        public bool IsHygienic { get; set; }
        public bool IsSocialDistanceViolated { get; set; }
        public int NotifyId { get; set; }
        public virtual Notify? Notify { get; set; }
    }
}