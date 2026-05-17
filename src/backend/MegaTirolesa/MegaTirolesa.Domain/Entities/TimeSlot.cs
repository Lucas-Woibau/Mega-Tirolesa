namespace MegaTirolesa.Domain.Entities
{
    public class TimeSlot : BaseEntity
    {
        protected TimeSlot() { }
        public TimeSlot(DateTime startTime, DateTime endTime, int maxCapacity, bool isActive)
            : base()
        {
            StartTime = startTime;
            EndTime = endTime;
            MaxCapacity = maxCapacity;
            IsActive = isActive;
        }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int MaxCapacity { get; private set; }
        public bool IsActive { get; private set; }
        public Appointment[] Appointments { get; private set; } = [];

        public void Update(DateTime startTime, DateTime endTime, int maxCapacity)
        {
            StartTime = startTime;
            EndTime = endTime;
            MaxCapacity = maxCapacity;
        }
    }
}
