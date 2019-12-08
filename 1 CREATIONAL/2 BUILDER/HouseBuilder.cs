using System;

namespace HouseBuilder
{
    // IBuilder
    public interface IHouseBuilder
    {
        void BuildWalls();
        void BuildRoof();


        ProductHouse GetHouse();
    }

    //Product
    public class ProductHouse
    {
        public int NumOfWalls { get; set; }
        public string RoofTop { get; set; }

        // displayinfo

        public void ShowInfo()
        {
            System.Console.WriteLine("Walls {0}", NumOfWalls);
            System.Console.WriteLine("RoofTop {0}",RoofTop);
        }
    }

    //ConcreteBuilder

    public class ConcreteHouseBuilder:IHouseBuilder
    {
         ProductHouse _productHouse = new ProductHouse();

        public  void BuildWalls()
        {
            _productHouse.NumOfWalls = 8;
        }
        public void BuildRoof()
        {
            _productHouse.RoofTop = "stro";
        }

        public ProductHouse GetHouse()
        {
            return  _productHouse;
        }

       
    }
    //Director

    public class HouseDirector
    {
        private readonly IHouseBuilder _houseBuilder;

        public HouseDirector(IHouseBuilder HouseBuilder)
        {
            this._houseBuilder =HouseBuilder;

        }
        
        public void CreateHouse()
        {
            _houseBuilder.BuildWalls();
            _houseBuilder.BuildRoof();
        }

        public  ProductHouse GetHouse()
        {
            return _houseBuilder.GetHouse();

        }

    }

    //Client

    public class HouseClient
    {

        public HouseClient()
        {
            var director = new HouseDirector(new ConcreteHouseBuilder() );
            director.CreateHouse();
            var house = director.GetHouse();
            house.ShowInfo();

        }
    }
}