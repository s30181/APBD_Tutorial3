namespace Tutorial3;

public class GasContainer(double containerMass, double maxMass, double height, double depth) 
    : Container<GasCargo>(containerMass, maxMass, height, depth), IHazardNotifier<GasCargo>
{
    
    public override void Empty()
    {
        CargoMass *= 0.05;
        CargoType = null;
    }

    public void Send(string? message, SerialNumber<GasCargo> serial)
    {
        Console.WriteLine($"Hazard: {message} with container's serial number: {serial}");
    }

    public override string ToString()
    {
        return $"G {base.ToString()}";

    }
}