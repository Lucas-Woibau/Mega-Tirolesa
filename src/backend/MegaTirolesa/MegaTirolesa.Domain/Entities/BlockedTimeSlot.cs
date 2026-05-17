namespace MegaTirolesa.Domain.Entities
{
    public class BlockedTimeSlot : BaseEntity
    {
        protected BlockedTimeSlot() { }
        public BlockedTimeSlot(Guid idTimeSlot, DateTime startTime, DateTime endTime, string reason)
            : base()
        {
            IdTimeSlot = idTimeSlot;
            StartTime = startTime;
            EndTime = endTime;
            Reason = reason;
        }
        public Guid IdTimeSlot { get; private set; }
        public TimeSlot TimeSlot { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Reason { get; private set; } = string.Empty;

        public void Update(DateTime startTime, DateTime endTime, string reason)
        {
            StartTime = startTime;
            EndTime = endTime;
            Reason = reason;
        }
    }
}
