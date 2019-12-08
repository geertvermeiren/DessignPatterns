using System;
using System.Collections.Generic;
using System.Linq;

//adding additional dynamic behavior to objects by placing them inside special wrapper 

namespace ProductionProcess
{
    public class Steps
    {
        public int Step { get; set; }
        public string Name { get; set; }
    }
    
    //component

    public abstract class Production
    {
        public List<Steps> process = new List<Steps>
        {
            new Steps{Step = 1, Name="step 1"},
            new Steps{Step = 2, Name="step 2"},
            new Steps{Step = 3, Name="step 3"}
        };

        public abstract int CountSteps();

    }
    
    //ConcreteComponent

    public class BasicProduction:Production
    {

       public override int CountSteps()
       {
          System.Console.WriteLine("number of stepts in the production process");
           return process.Count();
       }
    }

//Decorator

  public class ProcessDecorator: Production
  {
      Production _production;

      public ProcessDecorator(Production production)
      {
          this._production = production;
          
      }
      public override int CountSteps()
      {
          return _production.CountSteps();
      }
  }

//ConcreteDecorator

public class ComplexProduction:ProcessDecorator
{
    public ComplexProduction(Production production):base(production)
    {        
    }

    public override int CountSteps()
    {
        System.Console.WriteLine($"calculating the total steps of the complexProductionProcess");
        var complexProduction = base.CountSteps();
        return complexProduction + 15;
    }

}

//Client

public class Client
{
    public Client()
    {
        var bp = new BasicProduction();
        System.Console.WriteLine(bp.CountSteps());
        var cp = new ComplexProduction(bp);
        System.Console.WriteLine(cp.CountSteps());        
    }
}


}
