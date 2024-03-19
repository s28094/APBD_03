namespace DefaultNamespace;

public abstract class Container
{
    public string SerialNumber { get; }
    public double MassOfCargo { get; protected set; }
    public double Height { get; }
    public double TareWeight { get; }
    public double Depth { get; }
    public double MaximumPayload { get; }

    protected Container(string serialNumber, double height, double tareWeight, double depth, double maxPayload)
    {
        SerialNumber = serialNumber;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaximumPayload = maxPayload;
    }

    public abstract void LoadCargo(double cargoMass);
    public abstract void EmptyCargo();
}