using System;
using System.Collections.Generic;

//subject people entering a domain
//observer monitor 
namespace DomainObserver
{
    //subject
   public interface ISubject
   {
       void Subscribe(Observer observer);
       void UnSubscribe(Observer observer);
       void Notify();
       
   }
    //concrete subject
    public class Subject:ISubject
    {
        private readonly List<Observer> _observer = new List<Observer>();
        private int _int = 0;
        public string DomainName { get; set; }

        public int NumberOfPersonOmDomain
        {
            get{
                return _int;
            }
            set
            {
                if(value > _int)
                {
                    value =_int;
                    Notify();
                }
            }
        }

        public Subject(string domainName)
        {
            this.DomainName = domainName;
        }
        public void Subscribe(Observer observer)
        {
            _observer.Add(observer);

        }
        public void UnSubscribe(Observer observer)
        {
            _observer.Remove(observer);

        }

        public void Notify()
        {
            _observer.ForEach(x=> x.Update());
        }

    }

    //observer
    public interface IObserver
    {
        void Update();
    }

    //concrete observer
    public class Observer:IObserver
    {
        private Subject _subject;
        public string Name { get; set; }

        public Observer(Subject subject,string name)
        {
            this.Name = name;
            this._subject = subject;
        }

        public void Update()
        {
            
            System.Console.WriteLine($"a new person entered in the domain {_subject.DomainName} \n and is being watched now by {Name}");
        }
    }

    //client

    public class Client
    {
        public Client()
        {
        Subject s1 = new Subject("my domain");
        Observer o1 = new Observer(s1,"monitor 1");
        System.Console.WriteLine("***");
        s1.Subscribe(o1);
        


        }
    }
}
