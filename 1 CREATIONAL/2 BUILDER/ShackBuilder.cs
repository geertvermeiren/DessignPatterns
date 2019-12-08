using System;

namespace ShackBuilder
{
    //interface
    public interface IBuilder
    {
        void BuildWalls();

        void BuildRoof();

        Product GetProduct();        
    }

    //ConcreteProduct
    public class ConcreteProduct:IBuilder
    {
        Product _shack = new Product();

        public void BuildWalls()
        {
            _shack.Walls = " the walls are being built";
        }

        public void BuildRoof()
        {
            _shack.Roof = "the roof is being built";
        }

        public Product GetProduct()
        {
            return _shack;
        }
    }

    //Product
    public class Product
    {
        public string Walls { get; set; }
        public string Roof { get; set; }

        public void ShowInfo()
        {
            System.Console.WriteLine("Walls{0}",Walls);
            System.Console.WriteLine("Roof {0}", Roof);
        }
    }

    //Director
    public class Director
    {
        private readonly IBuilder _iBuilder; 

        public Director(IBuilder iBuilder)
        {
            this._iBuilder = iBuilder;
        }

        public void CreateShack()
        {
            _iBuilder.BuildWalls();
            _iBuilder.BuildRoof();
        }

        public Product GetProduct()
        {
            return _iBuilder.GetProduct();
        }

    }

    //client

    public class ShackClient
    {
        public ShackClient()
        {
            var director = new Director(new ConcreteProduct());
            director.GetProduct();
            var shack = director.GetProduct();
            shack.ShowInfo();
        }
    }
}