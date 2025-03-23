namespace Tutorial3;

public class LiquidContainer(double containerMass, double maxMass, double height, double depth) : Container<LiquidCargo>(containerMass, maxMass, height, depth), IHazardNotifier<LiquidCargo>
{
    
    public void Send(string? message, SerialNumber<LiquidCargo> serial)
    {
        Console.WriteLine($"{message} on {serial}");
    }



    public override void Load(LiquidCargo cargo, double mass)
    {
        var isHazardous = cargo switch
        {
            LiquidCargo.Milk => false,
            LiquidCargo.Fuel => true,
        };
        
        
        try
        {
            if (isHazardous && Mass + mass > MaxMass * 0.5)
            {
                throw new Exception();
            }

            if (Mass + mass > MaxMass * 0.9)
            {
                throw new Exception();
            }
        }
        catch (Exception e)
        {
            Send("Hazardous operation", Serial);
        }


        base.Load(cargo, mass);
    }

    public override string ToString()
    {
        return $"L {base.ToString()}";

    }
}