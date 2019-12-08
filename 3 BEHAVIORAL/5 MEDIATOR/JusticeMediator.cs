using System;
namespace JusticeMediator
{
    //mediator
    public interface Mediator
    {
        void SendMessage(string message,Justice justice);
    }


    //colleagues
    public abstract class Justice
    {
        Mediator _mediator;

        public Justice(Mediator mediator)
        {
            this._mediator = mediator;

        }

    }
    // concrete colleagues
    public class Plaintiff: Justice
    {
        public Plaintiff(Mediator mediator):base(mediator)
        {

        }

        public void Sent(string message)
        {
            System.Console.WriteLine($"plaintiff : {message}");
        }

        public void Notify(string message)
        {
            System.Console.WriteLine($"plaintiff : {message}");
        }


    }

   
    public class Defendant:Justice
    {
        public Defendant(Mediator mediator):base(mediator){}

        public void Sent(string message)
        {
            System.Console.WriteLine($"defendant : {message}");
        }
        public void Notify(string message)
        {
            System.Console.WriteLine($"defendant :{message}");
        }

    }

    //concrete mediator

    public class JusticeMediator: Mediator
    {
        Plaintiff _plaintiff;
        Defendant _defendant;

        public Plaintiff Plaintiff
        {
            set{_plaintiff = value;}
        } 
        public Defendant Defendant
        {
            set{_defendant = value;}
        }
        public void SendMessage(string message,Justice justice)
        {
            if(justice == _plaintiff)
            {
                _plaintiff.Notify(message);
            }else
            {
                _defendant.Notify(message);
            }
            
        }
    }

    public class Client
    {
        public Client()
        {
            JusticeMediator jm = new JusticeMediator();
            Plaintiff pt = new Plaintiff(jm);
            Defendant df = new Defendant(jm);

            jm.Plaintiff = pt;
            jm.Defendant = df;
            pt.Notify("hey you owe me 1000.0000 usd");
            df.Notify("sure i ll transfer it right away");

        }
    }



}