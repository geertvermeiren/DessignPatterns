using System;
using System.Collections.Generic;

namespace SofaFactor
{
    //creator
    public abstract class SofaCreator
    {
        public abstract ISofa Create(int quantity);
    }

    //concretecreator:creator

    public class ChaisseLongueCreator:SofaCreator
    {
        public override ISofa Create(int quantity)
        {
        return new ChaisseLonque(quantity);

        }      
        
    }

    //isofa
    public interface ISofa
    {
        void Operate();
    }

    //concrete product
    public class ChaisseLonque:ISofa
    {
        private readonly int _quantity; 

        public ChaisseLonque(int quantity)
        {
            this._quantity = quantity;

        }

        public void Operate()
        {
            System.Console.WriteLine("chaisse longue" + _quantity);
        }

    }

    //client

    public enum Actions
    {
        ChaisseLonque
    }

//     public class SofaStoreClient
//     {
//         private readonly Dictionary<Actions,SofaCreator> _factories;

//         public ISofa ExecuteCreation(Actions action, int quantity)
//         {
//             return _factories[action].Create(quantity); 

//         }

//         public SofaStoreClient()
//         {   _factories = new Dictionary<Actions, SofaCreator>();
//             _factories.Add(Actions.ChaisseLonque, new ChaisseLongueCreator());
//         }
        
//     }

// //4 
//     //run client

//     public class SofaClient
//     {
//         public SofaClient()
//         {
//            var ss = new SofaStoreClient().ExecuteCreation(Actions.ChaisseLonque,15);
//            ss.Operate();

//         }
//     }

public class SofaStoreClient
{    
    private readonly Dictionary<Actions, SofaCreator> _factories ;

    public ISofa ExecuteCreation(Actions action,int quantity)
    {
        return _factories[action].Create(quantity);
    }

    public SofaStoreClient()
    {
        _factories = new Dictionary<Actions, SofaCreator>();
        _factories.Add(Actions.ChaisseLonque,new ChaisseLongueCreator());
        

    }
}


}