using System;
using System.Collections.Generic;

namespace DashboardBridge
{
    //ABSTRACTION
    public abstract class DashBoard
    {
        public abstract void SpeedUP();      
        
        public abstract void Break();    



        
    }


    //REFINED ABSTRACTION
     public class DashBoardSportsCar:DashBoard
    {
        IEngine _engine;

        public DashBoardSportsCar(IEngine engine)
        {
            this._engine = engine;
        }
        public override void SpeedUP()
        {

            _engine.SetSpeed(_engine.GetSpeed()+10);

        }

        public override void Break()
        {
            _engine.SetSpeed(_engine.GetSpeed()-10);
        }

        public int GetCurrentSpeed()
        {
           return this._engine.GetSpeed();
        }
     
     
     
    }
    // IMPLEMENTATION
    public interface IEngine
    {
         void SetSpeed(int speed);

         int GetSpeed();
    }



    //CONCRETE IMPLEMENATION

    public class SportsCar:IEngine
    {
        int _speed; 

        public void SetSpeed(int speed)
        {
            this._speed = speed;
        }

        public int GetSpeed()
        {
            return this._speed;
        }

        

    }


    //client class
    public class Client
    {
         public Client()
         {
             DashBoardSportsCar _dashBoardSportsCar = new DashBoardSportsCar(new SportsCar()); 
             _dashBoardSportsCar.SpeedUP();
             _dashBoardSportsCar.SpeedUP();
             _dashBoardSportsCar.SpeedUP();
             _dashBoardSportsCar.SpeedUP();
             _dashBoardSportsCar.SpeedUP();
             _dashBoardSportsCar.SpeedUP();
             System.Console.WriteLine("CURRENT SPEED:");
            System.Console.WriteLine( _dashBoardSportsCar.GetCurrentSpeed());
             _dashBoardSportsCar.Break();
             _dashBoardSportsCar.Break();
             System.Console.WriteLine("CURRENT SPEED:");
            System.Console.WriteLine( _dashBoardSportsCar.GetCurrentSpeed());
         
         }
    }
}