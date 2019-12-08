using System;

namespace AirPlaneState
{
    //state
    public abstract class Flight
    {
        protected AirPlane _airplane;
        protected int _currentHeight;
        protected int _minHeight;
        protected int _maxHeight;

        public int CurrentHeight
        {
            get{return _currentHeight;}
            set{_currentHeight = value;}
        }

        public AirPlane AirPlane
        {
            get{return _airplane;}
            set{_airplane =value;}
        }

       public abstract void AddHeight(int foot);
       public abstract void CheckHeight();   
       
    }
    //concrete state
    public class Taxi:Flight
    {
        public Taxi(Flight state):this(state.CurrentHeight,state.AirPlane){}

        public Taxi(int currentHeight,AirPlane airplaine)
        {
            this._currentHeight = currentHeight;
            this._airplane = airplaine;
            Initialize();
        }

        public void Initialize()
        {
            _minHeight = 0;
            _maxHeight = 0;
        }

        public override void AddHeight(int foot)
        {
            this.CurrentHeight += foot; 
            CheckHeight();           
        }

        public override void CheckHeight()
        {
            _airplane._state = new Takeoff(this);
        }
    }

    public class Takeoff:Flight
    {
        public Takeoff(Flight state):this(state.CurrentHeight,state.AirPlane)
        {}

        public Takeoff(int currentHeight,AirPlane airplane)
        {
            this._currentHeight = currentHeight;
            this._airplane = airplane;
            Initialize();
        }

        public void Initialize()
        {
            this._minHeight = 1;
            this._maxHeight = 8000;
        }

        public override void AddHeight(int foot)
        {
            this._currentHeight += foot;
            CheckHeight();

        }

        public override void CheckHeight()
        {
            this._airplane._state = new Cruising(this);
        }
    }

    public class Cruising:Flight
    {
        public Cruising(Flight state):this(state.CurrentHeight,state.AirPlane){}

        public Cruising(int currentHeight,AirPlane airplane)
        {
            this._currentHeight =currentHeight;
            this._airplane =airplane;
            Intialize();
        }

        public void Intialize()
        {
            this._minHeight = 8001;
            this._maxHeight = 12001;
        }

        public override void AddHeight(int foot)
        {
            this._currentHeight += foot;
        }
        public override void CheckHeight()
        {

        }
    }
    //context
    public class AirPlane
    {
        public Flight _state;

        public AirPlane()
        {
            _state = new Taxi(0,this);
        }

        public int CurrentHeight
        {
            get{return _state.CurrentHeight;}
            set{_state.CurrentHeight = value;}
        }

        public Flight State
        {
            get{return _state;}
            set{_state = value;}
        }

        public void AddHeight(int foot)
        {   
            _state.AddHeight(foot);
            System.Console.WriteLine($"The airplane is gain {CurrentHeight} foot in height");
            System.Console.WriteLine($"The airplane is now in {State.GetType().Name} ");

        }

    }

    public class Client
    {
        public Client()
        {
            AirPlane ap = new AirPlane();
            ap.AddHeight(0);
            ap.AddHeight(1000);
            ap.AddHeight(5000);
            ap.AddHeight(1000);

        }
    }
}