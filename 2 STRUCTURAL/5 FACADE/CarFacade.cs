using System;

namespace CarFacade
{

 // facade 

    public class Facade
    {
        public Engine _engine; 

        public Breaks _breaks; 

        public Facade(Engine engine,Breaks breaks)
        {
            this._engine = engine;
            this._breaks = breaks;
        }

        public string Operation()
        {
            string result = "facade initializes subsystem: \n";
            result += this._engine.Operation1();
            result += this._engine.Operation2();
            result = "facade initializes subsystem: \n";
            result += this._breaks.Operation1();
            result += this._breaks.Operation3();

            return result;

        }
    }

    //subsystem 1

    public class Engine
    {
        public string Operation1()
        {
            return this.GetType().Name +"operation 1" ;
        }
        public string Operation2()
        {
            return this.GetType().Name + "operation 2";
        }
        public string Operation3()
        {
            return  this.GetType().Name+ "operation 3";
        }
    }
    public class Breaks 
    {
    
        public string Operation1()
        {
            return this.GetType().Name + "operation 1";
        }
        public string Operation2()
        {
            return this.GetType().Name + "operation 2";
        }
        public string Operation3()
        {
            return this.GetType().Name +"operation 3";
        }

    }
    //client
    class Client
    {
        // The client code works with complex subsystems through a simple
        // interface provided by the Facade. When a facade manages the lifecycle
        // of the subsystem, the client might not even know about the existence
        // of the subsystem. This approach lets you keep the complexity under
        // control.
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }
    
}