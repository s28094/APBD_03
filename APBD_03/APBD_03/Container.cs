namespace DefaultNamespace;
using System;

public abstract class Container
{
    private static int _containerCount = 0;
    public string SerialNumber { get; }
    public double MassOfCargo { get; protected set; }
    public double Height { get; }
    public double TareWeight { get; }
    public double Depth { get; }
    public double MaximumPayload { get; }

    protected Container(string containerType, double height, double tareWeight, double depth, double maxPayload)
    {
        _containerCount++;
        SerialNumber = $"KON-{containerType}-{_containerCount}";
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaximumPayload = maxPayload;
    }

    public abstract void LoadCargo(double cargoMass);
    public abstract void EmptyCargo();
    public abstract void NotifyHazard(string containerNumber);
}
