namespace Tutorial3;

public class Ship(double maxSpeed, int maxContainers, double maxWeight)
{
    private static int LastSerial = 0;
    private List<IContainer> Containers { get; set; } = [];

    public double MaxSpeed { get; set; } = maxSpeed;
    public int MaxContainers { get; set; } = maxContainers;
    public double MaxWeight { get; set; } = maxWeight;
    
    public int Serial { get; set; } = LastSerial++;

    public double CurrentMass
    {
        get
        {
            return Containers
                .Select(c => (Container<GasCargo>)c)
                .Select(c => c.Mass)
                .Sum();
        }
    }

    public void Load<T>(Container<T> container) where T : struct
    {
        if (Containers.Count == MaxContainers)
        {
            throw new Exception();
        }
        
        if (container.Mass + CurrentMass > MaxWeight)
        {
            throw new Exception();
        }
        
        Containers.Add(container);
    }

    public void Load(List<IContainer> containers)
    {
        if (Containers.Count + containers.Count >= MaxContainers)
        {
            throw new Exception();
        }

        var containersMass = containers
            .Select(c => (Container<GasCargo>)c)
            .Select(c => c.CargoMass + c.ContainerMass)
            .Sum();


        if (CurrentMass + containersMass > MaxWeight)
        {
            throw new Exception();
        }
            
        
        Containers.AddRange(containers);
    }

    public void Remove<T>(SerialNumber<T> serialNumber) where T : struct
    {
        var container = Containers.Find(c => ((Container<T>)c).Serial == serialNumber);

        if (container == null)
        {
            throw new Exception();
        }
        
        Containers.Remove(container);
    }

    public void Replace<T>(SerialNumber<T> serialNumber, IContainer newContainer, int number) where T : struct
    {
        Remove(serialNumber);
        
        Load(Enumerable.Repeat(newContainer, number).ToList());
    }

    public void Transfer<T>(SerialNumber<T> serial, Ship ship) where T : struct
    {
        var container = Containers
            .Select(c => (Container<T>)c)
            .FirstOrDefault(c => c.Serial == serial);
        

        if (container == null)
        {
            throw new Exception();
        }
        
        Remove(serial);
        
        ship.Load(container);
    }


    public override string ToString()
    {
        return $"Ship {Serial} (speed={MaxSpeed}, maxContainerNum={MaxContainers}, maxWeight={MaxWeight})";
    }
}