using System;
using System.Collections.Generic;

namespace AirCondioner
{

    public interface IAirConditioner
    {
        void Operate();
    }

    public class Cooling:IAirConditioner
    {
        private readonly double _temperature;

        public Cooling(double temperature)
        {
            this._temperature = temperature;

        }
        public void Operate()
        {
            System.Console.WriteLine("the airconditioner is cooling now");
        }

    }

    public class Warming:IAirConditioner
    {
        public readonly double _temperature;
        public Warming(double temperature)
        {
            this._temperature = temperature;

        }
        public void Operate()
        {
            System.Console.WriteLine("the airconditioner is warming");
        }

    }

    public abstract class AirConditionerFactory
    {
        public abstract IAirConditioner Create(double temperature);
    }

    public class CoolingFactory:AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature)
        {
            return new Cooling(temperature);
        }
    }

    public class WarmingFactory:AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature)
        {
            return new Warming(temperature);
        }
    }
     public enum Actions
     {
         Cooling,
         Warming

     }


public class AirConditioner
{
     public IAirConditioner ExecuteCreation(Actions action, double temperature) =>_factories[action].Create(temperature);
    private readonly Dictionary<Actions,AirConditionerFactory> _factories; 

    public AirConditioner()
    {
        _factories = new Dictionary<Actions, AirConditionerFactory>();

        _factories.Add(Actions.Cooling, new CoolingFactory());
        _factories.Add(Actions.Warming, new WarmingFactory());         
      
    }   
      
    }

}




