using System.Reflection.Emit;

namespace Tutorial3;



public class CLI
{
    private readonly List<Ship> Ships = [
        new (20.0, 20, 100.0)
    ];
    private readonly List<IContainer> Containers = [
    ];

    private Dictionary<string, Action> Commands;

    private Dictionary<string, Action> AvailableCommands
    {
        get
        {

            return Commands.Where((command, index) =>
            {
                if (Ships.Count == 0)
                {
                    return index == 0;
                }

                return true;
            })
            .ToDictionary();
        }
    }

    public CLI()
    {
        Commands = new Dictionary<string, Action>()
        {
            ["Add ship"] = AddShip,
            ["Remove ship"] = RemoveShip,
            ["Remove container"] = RemoveContainer,
            ["Add container"] = AddContainer,
            ["Load container on the ship"] = LoadCOntainerOnTheShip,
            ["Remove container from the ship"] = RemoveContainerFromShip,
            ["Empty the container"] = EmptyTheContainer,
        };
    }

    private void EmptyTheContainer()
    {
        Console.WriteLine("Container serial: ");
        var serial = ISerialNumber.Parse(Console.ReadLine());
        
        var container = Containers.Find(container => ((Container<GasCargo>)container).Serial == serial);
        if (container == null)
            throw new Exception($"Container not found: {serial}");
        
        ((Container<GasCargo>)container).Empty();
    }

    private void RemoveContainerFromShip()
    {
        Console.Write("Ship serial: ");
        var shipSerial = int.Parse(Console.ReadLine());
        
        var ship = Ships.FirstOrDefault(s => s.Serial == shipSerial);
        if (ship == null)
            throw new Exception($"Ship serial {shipSerial} not found");
        
        Console.WriteLine("Container serial: ");
        var containerSerial = ISerialNumber.Parse(Console.ReadLine());
        ship.Remove((SerialNumber<GasCargo>)containerSerial);
        
    }

    public void start()
    {
        while (true)
        {
            PrintState();
            PrintAvailableCommands();

            try
            {
                var input = Console.ReadLine();

                if (input == null)
                {
                    throw new Exception("Input is null");
                }
                var command = int.Parse(input);

                if (command >= AvailableCommands.Count)
                {
                    throw new Exception("Invalid command");
                }
                
                AvailableCommands.ElementAt(command).Value.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
    

    private void LoadCOntainerOnTheShip()
    {
        Console.Write("Ship serial: ");
        var shipSerial = int.Parse(Console.ReadLine());
        var ship = Ships.FirstOrDefault(s => s.Serial == shipSerial);

        if (ship == null)
        {
            throw new Exception();
        }
        
        Console.Write("Container serial number: ");
        var containerSerial = ISerialNumber.Parse(Console.ReadLine());

        var container = Containers.Find(container => ((Container<GasCargo>)container).Serial == containerSerial);

        if (container == null)
        {
            throw new Exception($"Serial number {containerSerial} does not exist");
        }
        
        ship.Load((Container<GasCargo>)container);
    }

    private  void RemoveContainer()
    {
        Console.Write("Serial number: ");
        var serialNumber = Console.ReadLine();
        var serial = ISerialNumber.Parse(serialNumber);

        var container = Containers.Find(container => ((Container<GasCargo>)container).Serial == serial);

        if (container == null)
        {
            throw new Exception($"Serial number {serialNumber} does not exist");
        }
        
        Containers.Remove(container);
    }

    private void RemoveShip()
    {
        Console.Write("Serial number: ");
        var serial = int.Parse(Console.ReadLine());
        var ship = Ships.FirstOrDefault(s => s.Serial == serial);

        if (ship == null)
        {
            throw new Exception();
        }

        Ships.Remove(ship);
    }

    private void PrintState()
    {
        var stringShips = Ships.Count == 0 ? "None" : string.Join(", \n", Ships);
        var stringContainers = Containers.Count == 0 ? "None" : string.Join(", \n", Containers);
        
        Console.WriteLine($"\nList of container ships: \n{stringShips}");
        Console.WriteLine($"\nList of containers: \n{stringContainers}");
    }

    private void AddContainer()
    {
        Console.Write("Container type: ");
        var containerType = Console.ReadLine();
        
        Console.Write("Container mass: ");
        var containerMass = double.Parse(Console.ReadLine());

        Console.Write("Max mass: ");
        var maxMass = double.Parse(Console.ReadLine());

        Console.Write("Depth: ");
        var depth = double.Parse(Console.ReadLine());
        
        Console.Write("Height: ");
        var height = double.Parse(Console.ReadLine());


        IContainer? container = null;
        if (containerType == "C")
        {
            Console.Write("Temperature: ");
            var temperature = double.Parse(Console.ReadLine());

            container = new RefrigeratedContainer(containerMass, maxMass, height, depth, temperature);
        }

        if (containerType == "G")
        {
            container = new GasContainer(containerMass, maxMass, height, depth);
        }

        if (containerType == "L")
        {
            container = new LiquidContainer(containerMass, maxMass, height, depth);
        }

        if (container == null)
        {
            throw new Exception();
        }
        
        Containers.Add(container);
    }

    private void AddShip()
    {
        Console.Write("Ship weight: ");
        var shipWeight = double.Parse(Console.ReadLine());
        
        Console.Write("Ship speed: ");
        var shipSpeed = double.Parse(Console.ReadLine());
        
        Console.Write("Ship max containers: ");
        var maxContainers = int.Parse(Console.ReadLine());
        
        Ships.Add(new Ship(shipSpeed, maxContainers, shipWeight));
    }
    
    private void PrintAvailableCommands()
    {
        AvailableCommands.Select((command, index) => $"{index}. {command.Key}")
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine("quit - quit the application");
        
        Console.Write(">: ");
    }
    

    
    
    
}