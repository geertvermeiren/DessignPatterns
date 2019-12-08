using System;

namespace HumanStepsState
{
    //state
    public abstract class Steps
    {
        protected Human _human;

        protected int _currentSpeed;
        protected int _minSpeed;
        protected int _maxSpeed;

        public Human Human
        {
            get{return _human;}
            set{_human = value;}
        }
        public int CurrentSpeed
        {
            get{return _currentSpeed;}
            set{_currentSpeed = value;}
        }


        public abstract void AddSpeed(int speed);

        public abstract void SpeedCheck();
        
                    
    }

    //concretestate

    public class StandStill:Steps
    {
        public StandStill(Steps state):this(state.CurrentSpeed,state.Human)
        {

        }
        public StandStill(int currentSpeed, Human human)
        {
            this._currentSpeed = currentSpeed;
            this.Human = human;
            Initialize();

        }


        public void Initialize()
        {
            _minSpeed = 0;
            _maxSpeed =1;

        }

        public override void AddSpeed(int speed)
        {
            _currentSpeed += speed;
            SpeedCheck();
        }
        public override void SpeedCheck()
        {
            _human._state = new Walk(this);
        }
    }

    public class Walk:Steps
    {
        public Walk(Steps state):this(state.CurrentSpeed, state.Human){}

        public Walk(int currentSpeed,Human human)
        {
            this._currentSpeed = currentSpeed;
            this._human = human;
            Initialize();


        }
        public void Initialize()
        {
            _minSpeed = 1;
            _maxSpeed = 8000;
        }

        public override void AddSpeed(int speed)
        {
            _currentSpeed += speed;
            SpeedCheck();

        }
        public override void SpeedCheck()
        {
            if(_currentSpeed > _maxSpeed)
            {
                _human._state = new Run(this);
            }
        }

    }

    public class Run:Steps
    {
        public Run(Steps state):this(state.CurrentSpeed, state.Human){}

        public Run(int currentSpeed,Human human)
        {
            _currentSpeed = currentSpeed;
            _human = human;
            Initialize();
        }
        public void Initialize()
        {
            _minSpeed = 8001;
            _maxSpeed = 50000;
        }

        public override void AddSpeed(int speed)
        {
            _currentSpeed += speed;
            SpeedCheck();
        }
        public override void SpeedCheck()
        {

        }
    }

    //context
    public class Human
    {
        public Steps _state;

        public Human()
        {
            _state = new StandStill(0,this);
        }

        public Steps State
        {
            get{return _state;}
            set{_state = value;}
        }

        public int CurrentSpeed
        {
            get{return _state.CurrentSpeed;}
        }

        public void AddSpeed(int speed)
        { 
            _state.AddSpeed(speed);
            System.Console.WriteLine($"you are progressing at a pace of {speed} steps per hour");
            System.Console.WriteLine($"you are  {_state.GetType().Name}ing");

        }



    }

    //client
    public class Client
    {
        public Client()
        {
            Human hm = new Human();
            hm.AddSpeed(0);
            hm.AddSpeed(5000);
            hm.AddSpeed(8500);
        }
    }
}