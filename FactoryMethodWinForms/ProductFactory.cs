public abstract class ProductFactory
{
    public abstract IProduct CreateProduct();
}

public class ConcreteProductAFactory : ProductFactory
{
    public override IProduct CreateProduct()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteProductBFactory : ProductFactory
{
    public override IProduct CreateProduct()
    {
        return new ConcreteProductB();
    }
}
