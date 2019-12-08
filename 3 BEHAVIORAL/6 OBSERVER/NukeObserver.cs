using System;
using System.Collections.Generic;

// when nuclear warheads are installed, they are being obsterverd in a controll center

// nukes are the subject
//control center = observer
namespace NukeObserver
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
        public string NukeId { get; set; }

        private int _int = 0;
        public Subject(string nukeId)
        {
            this.NukeId = nukeId;
           // Notify();// every time a new nukewarehead is created is will be observed.

        } 

        public int Nuke
        {
            get
            {
                return _int;
            }
            set
            {
                if(value > _int)
                { Notify();
                    value = _int;

                }
            }
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
            _observer.ForEach(x => x.Update());
        }

    }

    //Observer
    public  interface IObserver
    {
         void Update();

    }

    //concrete observer
    public class Observer:IObserver
    {   
        public string _observerName { get; set; }
        public Subject _subject { get; set; }
        public Observer(Subject subject,string observerName)
        {
            this._subject =  subject;
            this._observerName = observerName;           

        }

       public void Update()
       {
           System.Console.WriteLine($"a new nuke : {_subject.NukeId} is being installed ! {this.GetType().Name} is watching now");
       }
    }

    //client

    public class Client
    {
        public Client()
        {
            Subject nx2 = new Subject("nx2");
            Subject nx3 = new Subject("nx3");
            Observer usa = new Observer(nx2,"usa");
            nx2.Subscribe(usa);
            nx3.Subscribe(usa);
           nx2.Nuke++;  
           nx2.Nuke++;  
           nx3.Nuke++;
        }
    }

}
