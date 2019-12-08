using System;

namespace Bridge2
{

    public class Abstraction
    { 
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation)
        {
            this._implementation = implementation;

        }
        
        public virtual string Operation()
        {
            return "abstract base operatoin" + _implementation.OperationImplementation() ;
        }
    }

    public class ExtendedAbstraction: Abstraction
    {
        public ExtendedAbstraction(IImplementation implemenation):base(implemenation)
        {

        }
        public override string Operation()
        {

            return "extended abstraction" + base._implementation.OperationImplementation();
        }
        
    }

    //implementation
    public interface IImplementation
    {
        string OperationImplementation();
    }

    //concrete implemenationtiona: Iimplementation
    public class ConcreteImplementationA:IImplementation
    {

        public string OperationImplementation()
        {
            return "this is operation of concret A";
        }


    }

    public class ConcreteImplementationB:IImplementation
    {
        public string OperationImplementation()
        {
            return "concrete implementation B";
        }
    }

    //client

    public class AccessClient
    {
        public void ClientCode(Abstraction abstraction)
        {
            System.Console.WriteLine(abstraction.Operation());
        }
    }

    public class Client
    {
        
        AccessClient ac = new AccessClient();
        Abstraction abstraction = new Abstraction(new ConcreteImplementationA()); 
        


    }

}