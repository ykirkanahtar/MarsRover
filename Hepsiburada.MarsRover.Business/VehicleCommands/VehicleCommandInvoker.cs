namespace Hepsiburada.MarsRover.Business.VehicleCommands
{
    internal class VehicleCommandInvoker
    {
        internal void Execute(IVehicleCommand command)
        {
            command.Execute();
        }
    }
}
