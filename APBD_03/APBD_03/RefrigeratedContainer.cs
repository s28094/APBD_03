namespace DefaultNamespace;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public string ProductType { get;set; }
    public double RequiredTemperature { get;set; }

    public RefrigeratedContainer( double height, double tareWeight, double depth, double maxPayload, string productType, double requiredTemperature)
        : base("C", height, tareWeight, depth, maxPayload)
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

    public override void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazardous situation detected in refrigerated container: {containerNumber}");
    }
}