namespace ParkingManager.BusinessLogic.Commands
{
    public class CommandInvoker
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public async Task ExecuteCommandsAsync()
        {
            foreach (var command in _commands)
            {
                await command.ExecuteAsync();
            }
        }
    }
}
