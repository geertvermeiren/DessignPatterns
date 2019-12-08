using System;
namespace WaterLevelState
{
    //state abstract

    public abstract class WaterLevel
    {
        public Lake lake ;
        public int currentLevel ;
        public int maxTreshold ;
        public int minTreshold ;        
        public int rain ;

        public Lake Lake
        {
            get{ return lake;}
            set{lake = value;}
        }

        public int CurrentLevel
        {
            get{return currentLevel;}
            set{currentLevel = value;}
        }

        public abstract void Rain(int amount);
        public abstract void GetLevel();
    }

    //concrete state = dry,normal, floating

    public class NormalLevel:WaterLevel
    {
             
        public NormalLevel(WaterLevel waterLevel)
        {
          
            currentLevel = waterLevel.CurrentLevel;
            lake = waterLevel.lake;
            Initialize();
        }
        public void Initialize()
        {
            minTreshold = 0;
            maxTreshold = 1000;
        }
        public override void Rain(int amount)
        {
            this.currentLevel += amount;
            GetLevel();
        }

        public override void GetLevel()
        {
            if(currentLevel > maxTreshold)
            {
                lake._level = new OverFlow(this);
            }

        }

    }


    public class OverFlow:WaterLevel
    {
        public OverFlow(WaterLevel waterLevel):this(waterLevel.CurrentLevel, waterLevel.Lake)
        {

        }

        public OverFlow(int currentLevel,Lake lake)
        {
            this.currentLevel = currentLevel;
            this.lake = lake;
            Initialize();

        }

        public void Initialize()
        {
            minTreshold = 1001;
            maxTreshold = 1000000;
        }

        public override void Rain(int amount)
        {
            this.currentLevel += amount;
            GetLevel();

        }
        public override void GetLevel()
        {
            if(currentLevel > maxTreshold)
            System.Console.WriteLine("the lake is overflowing... ");
        
        }

    }


    //the context = the lake

    public class Lake
    {
        public WaterLevel _level;
     
        public Lake()
        {
            _level = new OverFlow(10,this);
          
        }

        public WaterLevel Level
        {
            get{return _level;}
            set{_level =value;}
        }

        public int CurrentLevel
        {
            get{return _level.currentLevel;}
            set{_level.currentLevel = value;}
        }

        public void Rain(int amount)
        {
            _level.Rain(amount);
            System.Console.WriteLine($"the lake increased by {amount} liters");
            System.Console.WriteLine($"the current level is {CurrentLevel} liters");    
            System.Console.WriteLine($"the current status is: {Level.GetType().Name}");    
            Console.WriteLine("");
        }

    }

    //client
    public class Client
    {
        public Client()
        {
            Lake lake = new Lake();
            lake.Rain(100);
            lake.Rain(10000);
           

        }
    }
}