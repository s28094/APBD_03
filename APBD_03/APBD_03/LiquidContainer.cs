namespace DefaultNamespace;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    public double HazardCapacityPercentage { get; }
    
    public LiquidContainer(string serialNumber, double height, double tareWeight, double depth, double maxPayload, bool isHazardous)
        : base(serialNumber, height, tareWeight, depth, maxPayload)
    {
        IsHazardous = isHazardous;
        HazardCapacityPercentage = isHazardous ? 0.5 : 0.9;
    }

    public override void LoadCargo(double cargoMass)
    {
        if (cargoMass > MaximumPayload * HazardCapacityPercentage)
        {
            NotifyHazard(SerialNumber);
            throw new OverfillException("Cargo mass exceeds allowable payload.");
        }

        MassOfCargo = cargoMass;
    }

    public override void EmptyCargo()
    {
        MassOfCargo = 0.05 * MassOfCargo;
    }

    public override void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazardous situation detected in container: {containerNumber}");
        
    }
}
