namespace MegaTirolesa.Domain.Entities
{
    public class AcceptedTerm : BaseEntity
    {
        protected AcceptedTerm() { }
        public AcceptedTerm(Guid idAppointment, Guid idTerm)
            : base()
        {
            IdAppointment = idAppointment;
            IdTerm = idTerm;
        }

        public Guid IdAppointment { get; private set; }
        public Appointment Appointment { get; private set; }
        public Guid IdTerm { get; private set; }
        public Term Term { get; private set; }
        public DateTime AcceptedAt { get; private set; }
    }
}
