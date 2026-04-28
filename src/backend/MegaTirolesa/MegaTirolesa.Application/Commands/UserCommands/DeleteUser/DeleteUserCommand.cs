namespace MegaTirolesa.Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand
    {
        public Guid Id { get; set; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
