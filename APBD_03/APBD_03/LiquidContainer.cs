namespace DefaultNamespace;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set;}
    public double HazardCapacityPercentage { get; set;}
    
    public LiquidContainer( double height, double tareWeight, double depth, double maxPayload, bool isHazardous)
        : base("L", height, tareWeight, depth, maxPayload)
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
        MassOfCargo = 0;
    }

    public override void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazardous situation detected in container: {containerNumber}");
        
    }
}
