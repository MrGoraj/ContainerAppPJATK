// See https://aka.ms/new-console-template for more information


using ConsoleApp2.Model;

class Program
{
    static void Main(string[] args)
    {
        // Create a new ContainerShip
        ContainerShip ship = new ContainerShip(30.0, 100, 20000.0);

        // Create a new Container
        Container container1 = Container.CreateContainer(5000.0, 2.5, 500.0, 2.5, 6000.0);

        // Load cargo into the container
        container1.Load(5000.0);

        // Load the container onto the ship
        ship.LoadContainer(container1, 5000.0);

        // Print the ship info
        ship.PrintShipInfo();

        // Create a new CoolingContainer
        CoolingContainer coolingContainer = CoolingContainer.CreateCoolingContainer(3000.0, 2.5, 500.0, 2.5, 4000.0, "Fruits", -5.0);

        // Load the cooling container onto the ship
        ship.LoadContainer(coolingContainer, 3000.0);

        // Print the ship info
        ship.PrintShipInfo();

        // Remove the first container from the ship
        ship.RemoveContainer(container1);

        // Print the ship info
        ship.PrintShipInfo();
    }
}