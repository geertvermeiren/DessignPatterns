using System;
namespace BuildingState
{
    //state
    public abstract class Completeness
    {
        public Building _building { get; set; }
        public int _currentState { get; set; }
        public int _min { get; set; }
        public int _max { get; set; }
        public abstract void AddPercent(int quantity);
        public abstract void CheckCompleteness();
    }

    //concrete state
    public class Start:Completeness
    {
        public Start(Completeness state):this(state._currentState,state._building)
        {
        }
        public Start(int _currentState,Building building)
        {            
            this._currentState = _currentState;
            this._building = building;
        }
        public void Initialize()
        {
            _min = 0;
            _max = 30;
        }
        public override void AddPercent(int quantity)
        {
            this._currentState += quantity;
            CheckCompleteness();
        }
        public override void CheckCompleteness()
        {
           this._building._state = new Middle(this);
;        }
    }
    public class Middle:Completeness
    {
        public Middle(Completeness state):this(state._currentState,state._building)
        {
        }
        public Middle(int _currentState,Building building)
        {
            this._building = building;
            this._currentState = _currentState;
            Initialize();
        }
        public void Initialize()
        {
            this._min = 31;
            this._max = 70;
        }

        public override void AddPercent(int quantity)
        {
            this._currentState += quantity;
            CheckCompleteness();
        }
        public override void CheckCompleteness()
        {
            this._building._state = new Finished(this);

        }
    }
    public class Finished:Completeness
    {
        public Finished(Completeness State):this(State._currentState,State._building)
        {

        }

        public Finished(int _currentState,Building building)
        {
            this._building = building;
            this._currentState = _currentState;
            Initialize();
        }

        public void Initialize()
        {
          this._min = 71;
          this._max = 100; 

        }

        public override void AddPercent(int quantity)
        {
            this._currentState += quantity;
            CheckCompleteness();
        }
        public override void CheckCompleteness()
        {
           
        }

    }
    //context
    public class Building
    {
        public Completeness _state;
        
        public Building()
        {
            _state = new Start(0,this);
        }
        public Completeness State
        {
            get{return _state;}
            set{_state = value;}
        }

        public void AddPercent(int quantity)
        {
            _state.AddPercent(quantity);    
            System.Console.WriteLine($"the builing is for {_state._currentState}% ready");
            System.Console.WriteLine($"the completeness of the building can be qualified as {_state.GetType().Name}");
        }
    }

    //client

    public class Client
    {
        public Client()
        {   
            Building bd = new Building();
            bd.AddPercent(0);
            bd.AddPercent(15);
            bd.AddPercent(30);
            bd.AddPercent(50);

        }
    }
}