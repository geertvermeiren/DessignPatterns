using System;
using System.Collections.Generic;

namespace PlasticFactory
{
    //creator
    public abstract class PlasticCreator
    {
        public abstract IPlastic Create();
    }
    //concrete creator

    public class HardPlasticCreator:PlasticCreator
    {
        public override IPlastic Create()
        {
            return new HardPlastic();
        }

    }

    public class SoftPlasticCreator: PlasticCreator
    {
        public override IPlastic Create()
        {
            return new SoftPlastic();
        }
    }

    //product
    public interface IPlastic
    {
         string Operate();
    }

    //concrete product 

    public class HardPlastic:IPlastic
    {
        public string Operate()
        {
           return   "creating hard plastic";
        }
    }

    public class SoftPlastic:IPlastic
    {
        public string Operate()
        {
           return "creating soft plastic => horrible";
        }
    }
    //client class
    public class Client
    {
         public Client()
         {
             System.Console.WriteLine("hardplastic:");            
            ClientMethod(new HardPlasticCreator());
            System.Console.WriteLine("softplastic");
            ClientMethod(new SoftPlasticCreator());

         }

         public void ClientMethod(PlasticCreator plasticCreator)
         {
           System.Console.WriteLine( plasticCreator.Create().Operate());

         }
    }
}