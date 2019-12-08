using System;

namespace HouseBuilder2
{
    //interface
    public interface IHouseBuilder
    {
        void BuildWalls();
        void BuildRoof();
        House GetProduct();        
    }

     //product 
     
     public class House
     {
         public string Wall { get; set; }
         public string Roof { get; set; }

         public void GetInfo()
         {
             System.Console.WriteLine("walls {0}", Wall );
             System.Console.WriteLine("Roof {0}",Roof);
         }
     }
     //concrete product

     public class ConcreteHouse:IHouseBuilder
     {

          House _house = new House();
         public void BuildRoof()
         {
             _house.Roof = "what a roof";

         }

         public void BuildWalls()
         {
             _house.Wall = "wonderfull walls";
         }

         public House GetProduct()
         {
             return _house;
         }
     }


     //director

     public class Director
     {
         private readonly IHouseBuilder _houseBuilder; 

         public Director(IHouseBuilder houseBuilder)
         {
             this._houseBuilder = houseBuilder;

         }

         public void CreateHouse()
         {
             _houseBuilder.BuildRoof();
             _houseBuilder.BuildWalls();
         }

         public House GetProduct()
         {
             return GetProduct();
         }
     }

     public class Client
     {

         public Client()
         {
         var director = new Director(new ConcreteHouse());
         director.CreateHouse();
         var myHouse = director.GetProduct();
         myHouse.GetInfo();


         }
         
     }

    
}