using ConsoleApp2.Exception;

namespace ConsoleApp2.Model;

public class ContainerGas : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public ContainerGas(double height, double ownWeight, double depth, double maxLoadCapacity, double pressure, double loadMass)
        : base(height, ownWeight, depth, maxLoadCapacity, loadMass)
    {
        Pressure = pressure;
    }

    public virtual void Load(double loadMass)
    {
        if (loadMass > MaxLoadCapacity)
        {
            throw new OverfillException("Load mass is greater than the container's capacity.");
        }
        LoadMass = loadMass;
    }

    public virtual void Unload()
    {
        LoadMass = 0;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Hazard event occurred in container with serial number: {SerialNumber}");
    }
}