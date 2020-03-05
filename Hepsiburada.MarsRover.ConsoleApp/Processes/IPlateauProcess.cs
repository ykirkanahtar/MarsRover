using Hepsiburada.MarsRover.Business.Models;

namespace Hepsiburada.MarsRover.ConsoleApp.Processes
{
    public interface IPlateauProcess
    {
        Plateau CreatePlateau(string inputValue);
    }
}