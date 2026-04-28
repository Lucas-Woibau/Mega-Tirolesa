namespace MegaTirolesa.Application.Commands.AppointmentCommands.DeleteAppointment
{
    public partial class DeleteAppointmentCommand
    {
        public DeleteAppointmentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
