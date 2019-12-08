using System;

namespace F1Builder
{
    //interface
    public interface IF1Builder
    {
        void BuildBody();

        void BuildWheels();        
    }

    //ConcreteBuilder

    public class ConcreteF1Builder:IF1Builder
    {
        Product _f1 = new Product();
        public void BuildBody()
        {
            _f1.Body = "the body is being built";
        }
        public void BuildWheels()
        {
            _f1.Wheels = "the wheels are being built";
        }
        public Product GetProduct()
        {
            return _f1;
        }

    }


    // product
    public class Product
    {
        public string Body { get; set; }
        public string Wheels { get; set; }

        public void ShowInfo()
        {
            System.Console.WriteLine("Body {0}",Body);
            System.Console.WriteLine("Wheels {0}",Wheels);
        }
    }

    //director

    public class Director
    {
        private readonly IF1Builder _f1Builder; 
        public Director(IF1Builder f1Builder)
        {
            this._f1Builder = f1Builder;
        }
        public void CreateF1()
        {
            _f1Builder.BuildBody();
            _f1Builder.BuildWheels();
        }

        public Product GetProduct()
        {
            return GetProduct();
        }
    }

    //client,

    public class F1Client
    {

        public F1Client()
        {
            var director = new Director(new ConcreteF1Builder());
            director.CreateF1();
            var f1 = director.GetProduct();
            f1.ShowInfo();
        }
    }
}