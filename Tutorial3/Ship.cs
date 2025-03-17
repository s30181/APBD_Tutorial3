namespace Tutorial3;

public class Ship
{
    public List<Container> Containers { get; set; } = [];
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public int MaxWeight { get; set; }

    public void Load(Container container)
    {
        if (Containers.Count == MaxContainers)
        {
            throw new Exception();
        }
        
        Containers.Add(container);
    }

    public void Load(List<Container> containers)
    {
        if (Containers.Count + containers.Count >= MaxContainers)
        {
            throw new Exception();
        }   
        
        Containers.AddRange(containers);
    }

    public void Remove(SerialNumber serialNumber)
    {
        var container = Containers.Find(c => c.Serial == serialNumber);

        if (container == null)
        {
            throw new Exception();
        }
        
        Containers.Remove(container);
    }

    public void Replace(SerialNumber serialNumber, Container newContainer, int number)
    {
        this.Remove(serialNumber);
        // this.Load(new List(new Arr));
    }

    public void Transfer(SerialNumber serial, Ship ship)
    {
        var container = Containers.Find(c => c.Serial == serial);
        Remove(serial);

        if (container == null)
        {
            throw new Exception();
        }
        
        ship.Load(container);
    }
    
    
}