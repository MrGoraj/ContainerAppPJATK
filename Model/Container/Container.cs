using ConsoleApp2.Exception;

namespace ConsoleApp2.Model;

public class Container
{
    private static int _lastSerialNumber = 0;
    public double LoadMass { get; set; }
    public double Height { get; set; }
    public double OwnWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; private set; }
    public double MaxLoadCapacity { get; set; }

    public Container(double loadMass, double height, double ownWeight, double depth, double maxLoadCapacity)
    {
        LoadMass = loadMass;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        MaxLoadCapacity = maxLoadCapacity;
        SerialNumber = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        _lastSerialNumber++;
        return $"KON-C-{_lastSerialNumber}";
    }
    
    public void Load(double loadMass)
    {
        if (loadMass > MaxLoadCapacity)
        {
            throw new OverfillException("Load mass is greater than the container's capacity.");
        }
        LoadMass = loadMass;
    }

    public void Unload()
    {
        LoadMass = 0;
    }
}