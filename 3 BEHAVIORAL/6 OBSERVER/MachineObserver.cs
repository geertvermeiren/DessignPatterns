using System;
using System.Collections.Generic;

//notificatin 

namespace MachineObserver
{
    //subject
    public abstract class Machine
    {
        private int _outputInKg;

        private List<IFactory> _factory = new List<IFactory>();
        public Machine(int outputInKg)
        {
            this._outputInKg = outputInKg;
        }

        public void Attach(IFactory factory)
        {   
            _factory.Add(factory);
        }

        public void Detach(IFactory factory)
        {
            _factory.Remove(factory);
        }

        public void Notify()
        {
            foreach(IFactory f in _factory)
            {
                f.Output(this);
            }
        }

        public int OutPutInKg
    {
        get { return _outputInKg; }
        set
        {
            if (_outputInKg != value)
            {
                _outputInKg = value;
                Notify(); //Automatically notify our observers of price changes
            }
        }
    }

    }

    //concrete subject
    public class ChocolateMaker:Machine
    {
        public ChocolateMaker(int outputInKg):base(outputInKg)
        {}
    }

    //observer
    public interface IFactory
    {
        void Output(Machine machine);
    }

    //concrete observer
    public class ChocolateFactory:IFactory
    {
        private string _name;

    //    private ChocolateMaker _chocolateMaker;
        private int _minimumProduction;
        public ChocolateFactory(string name,int minimumProduction)
        {
            this._name = name;
            this._minimumProduction = minimumProduction;

        }

        public void Output(Machine machine)
        {
            System.Console.WriteLine($"Notified {_name} has output of {machine.OutPutInKg}");
            if(machine.OutPutInKg < _minimumProduction )
            {
                System.Console.WriteLine("****");
                System.Console.WriteLine($"IS NOT PRODUCING ENOUGH: {_name}");
                System.Console.WriteLine("****");
            }
        }
      
    }

    //client

    public class Client
    {
        public Client()
        {
            ChocolateMaker cm = new ChocolateMaker(5000);
            cm.Attach(new ChocolateFactory("callebout",3000));
            cm.Attach(new ChocolateFactory("de lacre",15000));
            cm.Attach(new ChocolateFactory("hanzen",2000));
            cm.OutPutInKg =2005;
            cm.OutPutInKg =10005;
            cm.OutPutInKg =1005;
            cm.OutPutInKg =20005;
        }
    }
}


