using System;

namespace WaterBoilerState
{
    //state
    public abstract class HeatingLevel
    {
        protected WaterBoiler waterBoiler;
        protected int currentTemp;
        protected int heating;

        protected int minTemp;

        protected int MaxTemp;


        public WaterBoiler WaterBoiler
        {
            get{return waterBoiler;}
            set{waterBoiler = value;}

        }
        public int CurrentTemp
        {
            get{ return currentTemp; }
            set{ currentTemp = value;}
        }

        public abstract void Heat(int celcius);

        public abstract void Heatingcheck();
    }

    //concrete state



    public class Cold:HeatingLevel
    {
        public Cold(HeatingLevel state)
        {
            currentTemp = state.CurrentTemp;
            WaterBoiler = state.WaterBoiler;
        }

        public void Initialize()
        {
            minTemp = 0;
            MaxTemp = 10;
        }

        public override void Heat(int celcius)
        {
            currentTemp += celcius;
            Heatingcheck();

        }

        public override void Heatingcheck()
        {
            if(currentTemp > MaxTemp)
            {
                waterBoiler.State2 = new Warm(this);
            }
        }



    }

    public class Warm:HeatingLevel
    {
        public Warm(HeatingLevel state):this(state.CurrentTemp, state.WaterBoiler){}

        public Warm(int CurrentTemp,WaterBoiler waterBoiler)
        {
            currentTemp = CurrentTemp;
            this.waterBoiler =waterBoiler;
            Initialize();
            
        }

        public void Initialize()
        {
            minTemp = 11;
            MaxTemp = 50;
        }

        public override void Heat(int celcius)
        {
            this.currentTemp += celcius;
            Heatingcheck();
        }

        public override void Heatingcheck()
        {
            if(currentTemp > MaxTemp)
            {
                waterBoiler.State2 = new Boiling(this);
            }
        }


    }

    public class Boiling:HeatingLevel
    {
        public Boiling(HeatingLevel state):this(state.CurrentTemp, state.WaterBoiler)
        {}
        public Boiling(int CurrentTemp, WaterBoiler waterBoiler)
        {
            this.currentTemp = CurrentTemp;
            this.waterBoiler = waterBoiler;
            Intitialize();
        }
        public void Intitialize()
        {
            minTemp = 50;
           
        }

        public override void Heat(int celcius)
        {
            this.currentTemp += celcius;
            Heatingcheck();
        }
        public override void Heatingcheck()
        {

        }

        
    }


    //context
    public class WaterBoiler
    {
        private HeatingLevel _state;

        public WaterBoiler()
        {
            _state = new Warm(0,this);
        }

        public int CurrentTemp
        {
            get{return _state.CurrentTemp;}
        }

        public HeatingLevel State2
        {
            get{return _state;}
            set{_state = value;}
        }

        public void Heat(int celcius)
        {  
            _state.Heat(celcius);
            System.Console.WriteLine($"the temperature is now  :{CurrentTemp} degrees celciis");
            System.Console.WriteLine($"the water is  {_state.GetType().Name} ");
        }

    }

    //client

    public class Client
    {
        public Client()
        {
            WaterBoiler wb = new WaterBoiler();
            wb.Heat(5);
            wb.Heat(40);
            wb.Heat(90);
            wb.Heat(100);

        }
    }
}