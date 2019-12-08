using System;
namespace MementoClass
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Memento CreateMemento()
        {
            Memento m = new Memento();
            m.SetState(this.Id,this.Name);
            return m;       

        }

        public void GetMemento(Memento memento)
        {
          
            this.Id = memento.Id;
            this.Name = memento.Name;
         
        }

        public void Print()
        {
            System.Console.WriteLine( $" id : {this.Id} \n name : {this.Name}");
        }
    }

    public class Memento
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void SetState(int id, string name)
        {
            this.Id = id;
            this.Name = name;

        }

        public void GetState(Product product)
        {
           product.Id = this.Id;
           product.Name = this.Name;
        }
    }

    public class Client
    {
        public Client()
        {
            Product p = new Product();
            p.Id = 1;
            p.Name = "geert";
           System.Console.WriteLine("memento created");
           var memento = p.CreateMemento();
           p.Print();
           System.Console.WriteLine("-----");
           p.Id = 2;
           p.Name = "patrizia";
           p.Print();
            p.Id = 3;
           p.Name = "max";
           p.Print();        
           System.Console.WriteLine("-----");
           p.GetMemento(memento);
           System.Console.WriteLine("memento setback");
           p.Print();
        } 
    }
}