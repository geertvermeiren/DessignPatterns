using System;

namespace GlassOfWaterState
{
    //state
    public abstract class Fullness
    {
        public GlassOfWater _glassOfWater { get; set; }
        public int _currentState { get; set; }
        public int _minQuantity { get; set; }
        public int _maxQuantity { get; set; }
        public abstract void AddWater(int quantity);
        public abstract void CheckLevel();
    }

    // concrete state
    
    public class Empty: Fullness
    {

        public Empty(Fullness state):this(state._currentState, state._glassOfWater){}

        public Empty(int quantity,GlassOfWater glassOfWater)
        {
            this._glassOfWater = glassOfWater;
            this._currentState = _currentState;
            Initialize();
        }

        public void Initialize()
        {
            this._minQuantity = 0;
            this._maxQuantity = 0;
        }

        public override void AddWater(int quantity)
        {
            this._currentState += quantity;
            CheckLevel();
        }
        public override void CheckLevel()
        {
            if(_currentState >_maxQuantity)
            _glassOfWater._state = new HalfFull(this);
        }
    }

    public class HalfFull:Fullness
    {
        public HalfFull(Fullness state):this(state._currentState,state._glassOfWater){}

        public HalfFull(int _currentState,GlassOfWater glassOfWater)
        {
            this._glassOfWater = glassOfWater;
            this._currentState = _currentState;
            Initialize();
        }

        public void Initialize()
        {
            this._minQuantity = 2;
            this._maxQuantity = 50;
        }
        public override void AddWater(int quantity)
        {
            this._currentState += quantity;
            CheckLevel();   
        }
        public override void CheckLevel()
        {
            if(_currentState >_maxQuantity)
            this._glassOfWater._state = new Full(this);
        }
    }


    public class Full:Fullness
    {
        public Full(Fullness state):this(state._currentState,state._glassOfWater){}

        public Full(int currentState,GlassOfWater glassOfWater)
        {
            this._currentState = currentState;
            this._glassOfWater = glassOfWater;
            Initialize();
        }

        public void Initialize()
        {
            this._minQuantity = 51;
            this._minQuantity = 100;

        }

        public override void AddWater(int quantity)
        {
            this._currentState += quantity;
        }

        public override void CheckLevel()
        {
            
        }

    }


    //context
    public class GlassOfWater
    {
        
        public Fullness  _state;

        public GlassOfWater()
        {
            _state = new Empty(0,this);
        }

        public Fullness state
        {
            get{return _state;}
            set{_state = value;}
        }
        public int CurrentState 
        { 
            get{return _state._currentState;}
        }  
      
        
        public void AddWater(int quantity)
        {
            _state.AddWater(quantity);
            System.Console.WriteLine($"the glass has {CurrentState} cl of water ");
            System.Console.WriteLine($"you should consider the glass {_state.GetType().Name} cl of water ");
        }
    }


    //client
    public class Client
    {
        public Client()
        {
            GlassOfWater gw = new GlassOfWater();
            gw.AddWater(0);
            gw.AddWater(20);
            gw.AddWater(32);
            gw.AddWater(30);

        }
    }
}