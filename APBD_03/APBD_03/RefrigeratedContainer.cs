namespace DefaultNamespace;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public string ProductType { get; }
    public double RequiredTemperature { get; }

    public RefrigeratedContainer(string serialNumber, double height, double tareWeight, double depth, double maxPayload, string productType, double requiredTemperature)
        : base(serialNumber, height, tareWeight, depth, maxPayload)
    {
        ProductType = productType;
        RequiredTemperature = requiredTemperature;
    }

    public override void LoadCargo(double cargoMass)
    {
        if (cargoMass > MaximumPayload)
        {
            throw new OverfillException("Cargo mass exceeds allowable payload.");
        }

        MassOfCargo = cargoMass;
    }

    public override void EmptyCargo()
    {
        MassOfCargo = 0;
    }

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazardous situation detected in refrigerated container: {containerNumber}");
    }
}