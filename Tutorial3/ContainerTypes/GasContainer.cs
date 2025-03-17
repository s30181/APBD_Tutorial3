namespace Tutorial3;

public class GasContainer : Container
{
    
    public override void Empty()
    {
        CargoMass *= 0.05;
    }

    public override void Load(Cargo cargo, double mass)
    {
        
        // throw new NotImplementedException();
    }
}