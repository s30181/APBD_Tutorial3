namespace Tutorial3;

public abstract class Container
{
    public double CargoMass { get; set; }
    public static double ContainerMass { get; set; }
    
    public double Height { get; set; }
    public double Depth { get; set; }
    
    public SerialNumber Serial { get; set; }
    public double MaxMass { get; set; }

    public abstract void Empty();

    public virtual void Load(Cargo cargo, double mass)
    {
        if (mass > this.MaxMass)
        {
            throw new Exception();
        }
        
        
    }
}