using System;

namespace HotelBuilder
{
    //interface
    public interface IHotelBuilder
    {
        void BuildWalls();
        void BuildRoof();

        HotelProduct GetProduct();

        Hotel GetHotel();    
        
    }

    //concreteBuilder

    public class ConcreteHotel: IHotelBuilder
    {
         HotelProduct _hotelProduct = new HotelProduct();
         Hotel _hotel = new Hotel();

         public void BuildWalls()
         {
             _hotelProduct.Wall = "walls are being built";

         }
         public void BuildRoof()
         {
            _hotelProduct.Roof = " the roof is being built";
         }

         public HotelProduct GetProduct()
         {
             return _hotelProduct;
         }

         public Hotel GetHotel()
         {
             return _hotel;
         }



    }

    // product

    public class HotelProduct
    {
        public string Wall { get; set; }
        public string Roof { get; set; }

        public void ShowInfo()
        {
            System.Console.WriteLine("Wall {0}", Wall);
            System.Console.WriteLine("Roof {0}", Roof);
        }
    }

    public class Hotel
    {
        public string Walls { get; set; }

    }

    //director

    public class Director
    {
        private readonly IHotelBuilder _iHotelBuilder;

        public Director(IHotelBuilder iHotelBuilder)
        {
            this._iHotelBuilder = iHotelBuilder;

        }

        public void CreateHotel()
        {
            _iHotelBuilder.BuildRoof();
            _iHotelBuilder.BuildWalls();
        }

        public HotelProduct GetProduct()
        {
            return GetProduct();
        }
        

    }

    //client

    public class Client
    {
        public Client()
        {
            var director = new Director(new ConcreteHotel());
            director.CreateHotel();
            var hotel = director.GetProduct();
            
            
            
        }
    }
}