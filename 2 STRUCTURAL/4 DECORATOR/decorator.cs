using System;

// Decorator is a structural design pattern that lets you attach
 //new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.

// 

namespace Decorator
{
     // operation that can be defined
    public abstract class Component
    {
        public abstract string Operation();
    }

    class ConcreteComponent:Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    abstract class Decorator: Component
    {
        protected Component _component;

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
            return "ConcreteComponent";
        }


    }
    class ConcreteDecoratorA: Decorator
    {
        public ConcreteDecoratorA(Component component):base(component)
        {

        }

        public override string Operation()
        {
            return "ConcreteComponent"; 
        }
    }

    class ConcreteDecoratorB: Decorator
    {
        public ConcreteDecoratorB(Component component) : base(component)
        {
            
        }

        public override string Operation()
        {
            return "concreteComponent B";
        }
    }

    class Client
    {
        public void ClientCode(Component component)
        {

            System.Console.WriteLine(" result " + component.Operation());
        }
    }







}