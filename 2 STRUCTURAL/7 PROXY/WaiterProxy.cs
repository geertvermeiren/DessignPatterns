using System;

/*  let's imagine that servers at a restaurant primarily do three things:

Take the patron's order.
Deliver the patron's order.
Process the diner's payment.*/

/*
Now imagine for a second that our Server instance is an experienced 
server who is helping train a newly-employed server. 
That new employee, from the patron's perspective, is still a server 
and will still behave as such. However, the new trainee cannot process payments yet, 
as he must first learn the ropes of taking and delivering orders.
We can create a Proxy to model this new employee. The Proxy will need to maintain 
a reference back to the Server instance so that it can call the Server instance's ProcessPayment()
method: */

namespace WaiterProxy
{

    //the subject
    public interface IServer
    {
        void TakeOrder(string order);
        string DeliverOrder();

        void ProcessPayment(string payment);
        
    }

    //the real subject

    public class Server: IServer
    {
        private string _order;

        public void TakeOrder(string order)
        {
            System.Console.WriteLine($"the server takes order for: {order}");
            _order = order;

        }

        public string DeliverOrder()
        {
            return _order;
        }

        public void ProcessPayment(string payment)
        {
            System.Console.WriteLine($"Payment for  order {payment} processed");
        }
    }


    //the proxy 

    public class NewServerProxy:IServer
    {
        Server _server = new Server();
        private string _order;

        public void TakeOrder(string order)
        {
            System.Console.WriteLine($"the server takes order for: {order}");
            _order = order;

        }

        public string DeliverOrder()
        {
            return _order;
        }

        public void ProcessPayment(string payment)
        {
           System.Console.WriteLine("trainee can not process payment ");
           _server.ProcessPayment(payment);
        }
    }

    public class Client
    {
        public Client()
        {
            NewServerProxy proxy = new NewServerProxy();
            System.Console.WriteLine();

            var myoder = "friet met biefsteak";

            proxy.TakeOrder(myoder);
            System.Console.WriteLine("delivering " + proxy.DeliverOrder());
            proxy.ProcessPayment("100 rs");

        }
    }




}