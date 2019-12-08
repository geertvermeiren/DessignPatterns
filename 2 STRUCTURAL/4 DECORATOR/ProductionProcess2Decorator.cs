using System;
using System.Collections.Generic;

namespace ProductionProcess2Decorator
{
    //component
    public class ProductionStep
    {
        public int step { get; set; }
    }

    public abstract class Production
    {
        public List<ProductionStep> _production = new List<ProductionStep>
        {
            new ProductionStep{step = 1},
            new ProductionStep{step = 2},
            new ProductionStep{step = 3},
            new ProductionStep{step = 4},
            new ProductionStep{step = 5}

        };

        public abstract int CountSteps();
    }

    //concrete component

    public class ProductionProcess:Production
    {
        public override int CountSteps()
        {
            return _production.Count;
        }
    }

    //decorator

    public class QualityControll:ProductionProcess
    {
        ProductionProcess _productionProcess;

        public QualityControll(ProductionProcess productionProcess)
        {
            this._productionProcess = productionProcess;
        }
    }

    //concrete decorator
     public class QualitySteps:QualityControll
    {
        public QualitySteps(ProductionProcess productionProcess):base(productionProcess)
        {

        }
        public override int CountSteps()
        { QualityControllSteps();
            return base.CountSteps() +10 ;
           
        }

        public void QualityControllSteps()
        {
            System.Console.WriteLine("adding quality controll");
        }
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
             ProductionProcess pp = new ProductionProcess();
             QualityControll qc= new QualityControll(pp);
            System.Console.WriteLine( qc.CountSteps());
         
         }
    }
}