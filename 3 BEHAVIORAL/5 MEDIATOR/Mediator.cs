using System;

namespace Mediator
{
    // <summary>
/// The Mediator interface, which defines a send message method which the concrete mediators must implement.
/// </summary>
    //mediator
    public interface Mediator
    {
        void SendMessage(string message,ConsessionStand consessionStand);
    }

    //colleage 

    public abstract class ConsessionStand
    {
        protected Mediator mediator;

        public ConsessionStand(Mediator mediator)
        {
            this.mediator = mediator;

        }
    }


    //concrete colleague

    public class NorthConcessionStand:ConsessionStand
    {
        public NorthConcessionStand(Mediator mediator):base(mediator)
        {
        }

        public void Sent(string message)
        {
            System.Console.WriteLine($"this is the message : {message}");
        }
        public void Notify(string message)
        {
            System.Console.WriteLine($"we are notified of: {message}");
        }

    }
    public class SouthConcessionStand:ConsessionStand
    {
        public SouthConcessionStand(Mediator mediator):base(mediator)
        {
        }

        public void Sent(string message)
        {
            System.Console.WriteLine($"this is the message : {message}");
        }
        public void Notify(string message)
        {
            System.Console.WriteLine($"we are notified of: {message}");
        }

    }



    //concrete mediator

    public class ConcessionMediator :Mediator
    {
        private NorthConcessionStand _northConcessionStand;
        private SouthConcessionStand _southConcessionStand;

        public NorthConcessionStand NorthConcession
        {
            set{_northConcessionStand = value;}
        }
        public SouthConcessionStand SouthConcession
        {
            set{_southConcessionStand = value;}
        }


        public void SendMessage(string message,ConsessionStand colleague)
        {
            if(colleague == _northConcessionStand)
            {
                _southConcessionStand.Notify(message);
            }else
            {
                _northConcessionStand.Notify(message);

            }


        }
    }
    //client
    public class Client
    {
        public Client()
        {
            ConcessionMediator cm = new ConcessionMediator();
            NorthConcessionStand leftKitchen = new NorthConcessionStand(cm);
            SouthConcessionStand rightKitchen = new SouthConcessionStand(cm);

            cm.NorthConcession = leftKitchen;
            cm.SouthConcession = rightKitchen;

            leftKitchen.Sent("i need some popcorn");
            rightKitchen.Sent("ok i´ll send you some");


        }
    }
}