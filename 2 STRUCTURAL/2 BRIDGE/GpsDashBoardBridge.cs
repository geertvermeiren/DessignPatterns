using System;
using System.Collections.Generic;
//bridge separate class in two separate classes who can be developped independently
namespace GpsDashBoardBridge
{
    //abstraction

    public abstract class GPS
    {
        public abstract int Position();

    }
    //refined abstractoin
    public class CarGPS:GPS
    {
        IEngine _engine;
      
        public CarGPS(IEngine engine)
        {
            this._engine = engine;
        }
        public override int Position()
        {
            return this._engine.GetPosition();
        }
        public void Drive(int lat,int longitude)
        {
           
       this._engine.SetLat(this._engine.GetLat()+lat);
       this._engine.SetLong(this._engine.GetLong()+longitude);

        }

    }

    
    //implementation

    public interface IEngine
    {
              
         int GetLat();

         int GetLong();

         void SetLat(int lat);
         void SetLong(int longitude);

          int GetPosition();
    }

    public class CarEngine:IEngine
    {
        int _lat;
        int _long;

      

        public int GetLat()
        {
            return _lat;
        }
        public int GetLong()
        {
            return _long;
        }
        public void SetLat(int lat)
        {
            this._lat = lat;
        }
        public void SetLong(int longitude)
        {
            this._long = longitude;
        }

        public int GetPosition()
        {
            return this._long * this._lat;
        }

    }
    //client class
    public class Client
    {
         public Client()
         {
             CarGPS cargps = new CarGPS(new CarEngine());
             cargps.Drive(15,33);
             System.Console.WriteLine("THIS IS MY POSITION:");
             System.Console.WriteLine(cargps.Position());
             cargps.Drive(15,33);
              System.Console.WriteLine("THIS IS MY POSITION");
             System.Console.WriteLine(cargps.Position());
         
         }
    }
}