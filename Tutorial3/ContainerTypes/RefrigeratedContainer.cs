namespace Tutorial3;

public class RefrigeratedContainer(double containerMass, double maxMass, double height, double depth, double temperature) : Container<ItemsCargo>(containerMass, maxMass, height, depth)
{
    public double Temperature { get; set; } = temperature;
    

    public override void Load(ItemsCargo cargo, double mass)
    {
        var temperature = cargo switch
        {
            ItemsCargo.Bananas => 13.3,
            ItemsCargo.Chocolate => 18,
            ItemsCargo.Fish => 2,
            ItemsCargo.Meat => -15,
            ItemsCargo.IceCream => -18,
            ItemsCargo.FrozenPizza => -30,
            ItemsCargo.Cheese => 7.2,
            ItemsCargo.Sausages => 5,
            ItemsCargo.Butter => 20.5,
            ItemsCargo.Eggs => 19,
        };

        if (Temperature < temperature)
        {
            throw new TemperatureException();
        }
    }

    public override string ToString()
    {
        return $"R {base.ToString()}, Temperature = {Temperature}";
    }
}