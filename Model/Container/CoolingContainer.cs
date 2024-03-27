namespace ConsoleApp2.Model;

public class CoolingContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    public CoolingContainer(double loadMass, double height, double ownWeight, double depth, double maxLoadCapacity, string productType, double temperature)
        : base(loadMass, height, ownWeight, depth, maxLoadCapacity)
    {
        ProductType = productType;
        Temperature = temperature;
    }

    public void LoadProduct(string productType, double requiredTemperature, double loadMass)
    {
        if (productType != ProductType)
        {
            throw new InvalidOperationException("This container can only store products of type: " + ProductType);
        }

        if (requiredTemperature > Temperature)
        {
            throw new InvalidOperationException("The temperature of the container cannot be lower than the temperature required by the product.");
        }

        Load(loadMass);
    }
}