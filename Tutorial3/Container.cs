using System.Data.SqlTypes;

namespace Tutorial3;

public interface IContainer 
{

}

public abstract class Container<T>(double containerMass, double maxMass, double height, double depth) : IContainer
where T : struct 
{
    public double ContainerMass { get; set; } = containerMass;

    public double MaxMass { get; } = maxMass;

    public double CargoMass { get; protected set; }
    
    public double Height { get; } = height;
    public double Depth { get; } = depth;
    
    public T? CargoType { get; protected set; } = null;

    public double Mass
    {
        get
        {
            return CargoMass + ContainerMass;
        }
    }

    public SerialNumber<T> Serial { get; } = new ();
    

    public virtual void Empty()
    {
        CargoMass = 0;
        CargoType = null;
    }
    
    public virtual void Load(T cargo, double mass)
    {
        if (ContainerMass + CargoMass + mass > MaxMass)
        {
            throw new OverfillException();
        }

        if (CargoType != null && !CargoType.Equals(cargo))
        {
            throw new Exception("Wrong cargo type");
        }

        CargoType = cargo;
        CargoMass += mass;
    }

    public override string ToString()
    {
        return $"Mass = {CargoMass}, Height = {Height}, Depth = {Depth}, Container Mass = {ContainerMass}, Serial = {Serial}";
    }
}