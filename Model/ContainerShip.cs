namespace ConsoleApp2.Model;

public class ContainerShip
{
    private List<Container> Containers { get; }
    private double MaxSpeed { get; }
    private int MaxContainerCount { get; }
    private double MaxWeight { get; }

    public ContainerShip(double maxSpeed, int maxContainerCount, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }
    
    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            throw new InvalidOperationException("The ship has reached its maximum container capacity.");
        }

        double currentWeight = Containers.Sum(c => c.LoadMass);
        if (currentWeight + container.LoadMass > MaxWeight)
        {
            throw new InvalidOperationException("The ship cannot carry more weight.");
        }
        Containers.Add(container);
    }
    
    public void LoadContainer(Container container, double loadMass)
    {
        container.Load(loadMass);
        AddContainer(container);
    }

// In the Container class
    public static Container CreateContainer(double loadMass, double height, double ownWeight, double depth, double maxLoadCapacity)
    {
        return new Container(loadMass, height, ownWeight, depth, maxLoadCapacity);
    }

    public void LoadCargo(Container container, double loadMass)
    {
        LoadContainer(container, loadMass);
    }

// In the CoolingContainer class
    public static CoolingContainer CreateCoolingContainer(double loadMass, double height, double ownWeight, double depth, double maxLoadCapacity, string productType, double temperature)
    {
        return new CoolingContainer(loadMass, height, ownWeight, depth, maxLoadCapacity, productType, temperature);
    }

// In the ContainerShip class
    public void LoadContainer(Container container)
    {
        AddContainer(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void ReplaceContainer(int index, Container newContainer)
    {
        if (index < 0 || index >= Containers.Count)
        {
            throw new ArgumentOutOfRangeException("index", "Index is out of range.");
        }
        Containers[index] = newContainer;
    }

    public static void TransferContainer(Container container, ContainerShip fromShip, ContainerShip toShip)
    {
        fromShip.RemoveContainer(container);
        toShip.AddContainer(container);
    }

    public void PrintContainerInfo(Container container)
    {
        Console.WriteLine($"Container info: LoadMass = {container.LoadMass}, Height = {container.Height}, OwnWeight = {container.OwnWeight}, Depth = {container.Depth}, MaxLoadCapacity = {container.MaxLoadCapacity}");
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship info: MaxSpeed = {MaxSpeed}, MaxContainerCount = {MaxContainerCount}, MaxWeight = {MaxWeight}");
        Console.WriteLine("Cargo info:");
        foreach (var container in Containers)
        {
            PrintContainerInfo(container);
        }
    }
}