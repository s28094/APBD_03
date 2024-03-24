namespace DefaultNamespace;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(string serialNumber, double height, double tareWeight, double depth, double maxPayload, double pressure)
        : base(serialNumber, height, tareWeight, depth, maxPayload)
    {
        Pressure = pressure;
    }

    public override void LoadCargo(double cargoMass)
    {
        if (cargoMass > MaximumPayload * 0.5)
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

public class OverfillException : Exception
{
    public OverfillException(string cargoMassExceedsAllowablePayload)
    {
        throw new NotImplementedException();
    }
}
