namespace Tutorial3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazrdous { get; set; }
    
    public void Send(string? message, SerialNumber serial)
    {
        throw new NotImplementedException();
    }

    public override void Empty()
    {
        throw new NotImplementedException();
    }

    public override void Load(Cargo cargo, double mass)
    {
        if (IsHazrdous && mass > MaxMass * 0.95)
        {
            throw new Exception();
        }

        if (mass > MaxMass * 0.90)
        {
            throw new Exception();
        }
        
        
    }
}