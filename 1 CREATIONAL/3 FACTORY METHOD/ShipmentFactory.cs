using System;
using System.Collections.Generic;

namespace ShipmentFactory
{
    //creator
     public abstract class ShipmentCreator
    {
        public abstract IShipment CreateShipment();    
         
    }
    //concrete creator

    public class RailShipmentCreator:ShipmentCreator
    {
        public override IShipment CreateShipment()
        {
            return new RailShipment();
        }
    }

    public class TruckShipmentCreator:ShipmentCreator
    {
        public  override IShipment CreateShipment()
        {
            return new TruckShipment();
        }

    }


    //product 
    public interface IShipment 
    {
        string Transport ();
    }
  

    //concrete product
    public class RailShipment:IShipment
    {
        public string Transport()
        {
            
            return $"this is a {this.GetType().Name}";
        }

    }

    public class TruckShipment:IShipment
    {
        public string Transport()
        {
            return $"this is a {this.GetType().Name}";
            
        }
    }


    //client class
    public class Client
    {
         public Client()
         {
             System.Console.WriteLine("truckshipment:");
            
             ClientCode(new TruckShipmentCreator());
         }

         public void ClientCode(ShipmentCreator shipmentCreator)
         {
             System.Console.WriteLine($"we are shiping our goods via {shipmentCreator.CreateShipment().Transport()}");

         }


         
    }
}