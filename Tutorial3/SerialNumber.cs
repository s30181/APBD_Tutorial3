namespace Tutorial3;

public interface ISerialNumber
{
    public static ISerialNumber Parse(string input)
    {
        var parts = input.Split("-");
        
        var number = int.Parse(parts[2]);
        ISerialNumber serial = parts[1] switch
        {
            "G" => new SerialNumber<GasCargo>(number),
            "C" => new SerialNumber<ItemsCargo>(number),
            "L" => new SerialNumber<LiquidCargo>(number),
            _ => throw new Exception()
        };
        
        return serial;
    }
}

public class SerialNumber<T> : ISerialNumber
{
    private static int LastNumber = 0;
    
    public Type CargoType { get; } = typeof(T);
    public int Number { get; }

    public SerialNumber()
    {
        Number = LastNumber++;
    }

    public SerialNumber(int number)
    {
        Number = number;
    }


    

    public override string ToString()
    {
        var dict = new Dictionary<Type, string>
        {
            { typeof(LiquidCargo), "L" },
            { typeof(GasCargo), "G" },
            { typeof(ItemsCargo), "C" },
        };
        
        return $"CON-{dict[CargoType]}-{Number}";
    }
}