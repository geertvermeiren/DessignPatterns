using System;
using System.Collections.Generic;

//persons are entering metrostation with name and observing the metro

namespace MetroObserver
{
    //concretesubject
    public class Subject
    {
        private readonly List<Observer> _observer = new List<Observer>();

        public string MetroStationName { get; set; }

        private int _int = 0;

        public int NumberOfPeopleInMetro
        {
            get
            {
                return _int;
            }
            set
            {
                if(value > _int)
                {
                    //System.Console.WriteLine("how much:" +NumberOfPeopleInMetro);
                    Notify();
                    value = _int;

                }
            }
        }

        public Subject(string MetroStationName)
        {
            this.MetroStationName = MetroStationName;
        }
         public void Subscribe(Observer observer)
         {
             _observer.Add(observer);
         }
        public void UnSubscribe(Observer observer)
        {
            _observer.Remove(observer);
        }
        void Notify()
        {
            _observer.ForEach(x => x.Update());
           
        }




    }

    //subject
    public interface ISubject
    {
        void Subscribe(Observer observer);
        void UnSubscribe(Observer observer);
        void Notify();
    }

    //concrete observer
    public class Observer:IObserver
    {

        public Observer(string observerName, Subject _subject) 
        {
            this.ObserverName = observerName;
                this._subject = _subject;
               
        }
                public string ObserverName { get; set; }
        public Subject _subject { get; set; }
        
        public Observer(Subject subject,string observerName)
        {
            this._subject = subject;
            this.ObserverName = observerName;
            
        }
        public void Update()
        {
          

            System.Console.WriteLine($"{ObserverName} is watching {_subject.MetroStationName} \n because {_subject.NumberOfPeopleInMetro} are entering the metro ");

        }
    }

    //observer
    public interface IObserver
    {
        void Update();
    }

    //client
    public class Client
    {
        public Client()
        {
            Subject GareDuMidi = new Subject("Gare du Midi");
            Observer montor1 = new Observer(GareDuMidi,"monitor1");
            GareDuMidi.Subscribe(montor1);
            Observer montor2 = new Observer(GareDuMidi,"monitor2");
            GareDuMidi.Subscribe(montor2);
            System.Console.WriteLine("***");
            GareDuMidi.NumberOfPeopleInMetro++;
            GareDuMidi.NumberOfPeopleInMetro ++;
            GareDuMidi.NumberOfPeopleInMetro++;

        }
    }
}
