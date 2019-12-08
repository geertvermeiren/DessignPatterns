using System;

//adding new behaviour to objects dynamically by placing then inside a special wrapper
namespace Decorator2
{
    //component
    public abstract class Component
    {
        public abstract string Operation();
    }

    //concretecomponente:component

    public class ConcreteComponent:Component
    {
        public override string Operation()
        {
            return "concrete component";
        }
    }

    //decorator:component

    public class Decorator: Component
    {   protected Component _component;
        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }
        public override string Operation()
        {
            return "concrete component"; 
        }
    }

    //concretedecoratorA:decorator

    public class ConcreteDecoratorA:Decorator
    {
        public ConcreteDecoratorA(Component component) :base(component)
        {

        }

        public override string Operation()
        {
            return "overrride";
        }
    }

    //concretedecoratorB:decorator

    public class ConcreteDecoratorB:Decorator
    {
        public ConcreteDecoratorB(Component component) :base(component)
        {

        }
        public override string Operation()
        {
            return "override";
        }
    }

    //client
    public class Client
    {
        public void ClientCode(Component component)
        {
            System.Console.WriteLine("result " + component );
        }
    }




}