namespace Tutorial3;

public class RefrigeratedContainer : Container
{
    public int ProductType { get; set; }
    public double Temperature { get; set; }
    
    public override void Empty()
    {
        throw new NotImplementedException();
    }

    public void Load(int productType, double mass)
    {
        if (this.ProductType != productType)
        {
            throw new Exception();
        }
        
        
        throw new NotImplementedException();
    }
}