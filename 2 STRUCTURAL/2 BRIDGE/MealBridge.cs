using System;

//normal meal vs special meal  split in 2 and develop independently 

namespace MealBridge
{
    // abstraction
    public abstract class SendOrder
    {
        public IOrderingSystem _orderingSystem;

        public abstract void Send();
    }

     //redefined abstraction: abstraction
    //extened abstraction: abstraction

    public class SendDiaryFreeOrder:SendOrder
    {
        public override void Send()
        {
         _orderingSystem.Place("DiaryFreeOrder");
        }
    }

    //redefined abstraction:abstractoin

    public class GlutenFreeOrder:SendOrder
    {
        public override void Send()
        {
            _orderingSystem.Place("GLUTEN FREE ORDER");
        }
    }

    //implementator

    public interface IOrderingSystem
    {
        void Place(string order);

    }

    //concreteimplementation A:implementator

    
    public class NormalRestaurantOrder:IOrderingSystem
    {
        public void Place(string order)
        {
            System.Console.WriteLine($"placing order  for {order} at dinner at normal restaurant ");
        }
    }
    //concreteimplementation B: implementator

    public class  FancyRestaurantOrder:IOrderingSystem
    {
        public void Place(string order)
        {
            System.Console.WriteLine($"placing order for {order} at fancy restaurant");
        }
    }

    //client

    public class Client
    {
        public Client()
        {
            SendOrder _sendOrder = new SendDiaryFreeOrder();
            _sendOrder._orderingSystem = new NormalRestaurantOrder();
            _sendOrder.Send();

             
          

           
        }
    }





}