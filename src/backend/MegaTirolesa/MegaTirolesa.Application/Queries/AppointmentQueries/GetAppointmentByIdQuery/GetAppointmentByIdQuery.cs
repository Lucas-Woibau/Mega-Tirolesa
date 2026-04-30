namespace MegaTirolesa.Application.Queries.AppointmentQueries.GetAppointmentByIdQuery
{
    public class GetAppointmentByIdQuery
    {
        public Guid Id { get; set; }

        public GetAppointmentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
