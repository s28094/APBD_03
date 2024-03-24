namespace DefaultNamespace;

public class ContainerShip
{
    private List<Container> _containers = new List<Container>();
    public string ShipName { get; }
    public int MaxSpeed { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    public double CurrentWeight => _containers.Sum(c => c.MassOfCargo);

    public ContainerShip(string shipName, int maxSpeed, int maxContainers, double maxWeight)
    {
        ShipName = shipName;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= MaxContainers)
        {
            throw new Exception("Ship is at maximum capacity. Cannot load more containers.");
        }

        if (CurrentWeight + container.MassOfCargo > MaxWeight)
        {
            throw new Exception("Loading this container will exceed the ship's maximum weight.");
        }

        _containers.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} loaded onto {ShipName}.");
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        if (!_containers.Contains(container))
        {
            throw new Exception("Container not found on the ship.");
        }

        _containers.Remove(container);
        Console.WriteLine($"Container {container.SerialNumber} removed from {ShipName}.");
    }

    public void UnloadContainer(Container container)
    {
        if (!_containers.Contains(container))
        {
            throw new Exception("Container not found on the ship.");
        }

        container.EmptyCargo();
        _containers.Remove(container);
        Console.WriteLine($"Container {container.SerialNumber} unloaded from {ShipName}.");
    }

    public void ReplaceContainer(Container oldContainer, Container newContainer)
    {
        if (!_containers.Contains(oldContainer))
        {
            throw new Exception("Old container not found on the ship.");
        }

        if (newContainer.MassOfCargo > MaxWeight - CurrentWeight + oldContainer.MassOfCargo)
        {
            throw new Exception("Replacing this container will exceed the ship's maximum weight.");
        }

        _containers.Remove(oldContainer);
        _containers.Add(newContainer);
        Console.WriteLine($"Container {oldContainer.SerialNumber} replaced with {newContainer.SerialNumber} on {ShipName}.");
    }

    public void TransferContainer(Container container, ContainerShip otherShip)
    {
        if (!_containers.Contains(container))
        {
            throw new Exception("Container not found on the ship.");
        }

        otherShip.LoadContainer(container);
        _containers.Remove(container);
        Console.WriteLine($"Container {container.SerialNumber} transferred from {ShipName} to {otherShip.ShipName}.");
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Name: {ShipName}");
        Console.WriteLine($"Maximum Speed: {MaxSpeed} knots");
        Console.WriteLine($"Maximum Containers: {MaxContainers}");
        Console.WriteLine($"Maximum Weight: {MaxWeight} tons");
        Console.WriteLine($"Current Weight: {CurrentWeight} kg");

        Console.WriteLine("\nContainers on board:");
        foreach (var container in _containers)
        {
            Console.WriteLine($"Container: {container.SerialNumber}");
            Console.WriteLine($"  Type: {container.GetType().Name}");
            Console.WriteLine($"  Cargo Mass: {container.MassOfCargo} kg");
            Console.WriteLine($"  Height: {container.Height} cm");
            Console.WriteLine($"  Tare Weight: {container.TareWeight} kg");
            Console.WriteLine($"  Depth: {container.Depth} cm");
            Console.WriteLine($"  Maximum Payload: {container.MaximumPayload} kg");

            if (container is LiquidContainer liquidContainer)
            {
                Console.WriteLine($"  Is Hazardous: {liquidContainer.IsHazardous}");
            }
            else if (container is GasContainer gasContainer)
            {
                Console.WriteLine($"  Pressure: {gasContainer.Pressure} atm");
            }
            else if (container is RefrigeratedContainer refrigeratedContainer)
            {
                Console.WriteLine($"  Product Type: {refrigeratedContainer.ProductType}");
                Console.WriteLine($"  Required Temperature: {refrigeratedContainer.RequiredTemperature} °C");
            }

            Console.WriteLine();
        }
    }
}

