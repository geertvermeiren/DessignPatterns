using System;
using System.Collections.Generic;

namespace DivingRobotBridge
{
 //devide classes in sperate class hierarchie that can be developed seperately 
    //abstraction 

    public abstract class DivingInterface
    {

        public abstract void DiveDown();

        public abstract void GoUp();

    }

    //refined abstraction

    public class DivingRobot:DivingInterface
    {
        IEngine _engine;

        public DivingRobot(IEngine engine)
        {
            this._engine = engine;
        }
        public override void DiveDown()
        {
            this._engine.SetDepth(this._engine.GetDepth()-10);
        }

        public override void GoUp()
        {
            this._engine.SetDepth(this._engine.GetDepth()-10);
        }

        public int GetDepth()
        {
           return this._engine.GetDepth();
        }

    }

    

     //implementation interface
     public interface IEngine
     {
          int GetDepth();

          void SetDepth(int depth);
     }

     //concrete implementation 

     public class DivingEngine:IEngine
     {
         int _depth;

         public int GetDepth()
         {
             return _depth;
         }

         public void SetDepth(int depth)
         {
             this._depth = depth;
         }

     }

    //client class
    public class Client
    {
         public Client()
         {
             DivingRobot dr = new DivingRobot(new DivingEngine());
             dr.DiveDown();
             dr.DiveDown();
             dr.DiveDown();
             dr.DiveDown();
             dr.DiveDown();
             dr.DiveDown();
             System.Console.WriteLine($"{dr.GetDepth()} meters");
         
         }
    }
}