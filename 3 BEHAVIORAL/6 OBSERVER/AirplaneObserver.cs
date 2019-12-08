using System;
using System.Collections.Generic;

//observing airplane from controll tower.. if they get in range from airport 

namespace AirplaneObserver
{
    //subject
    public class Subject:ISubject
    {
        
        private List<Observer> _observer = new List<Observer>();
        //distance from airport in km
        private int _int;
        public string AirplaneName { get; set; }
        public Subject(string airplaneName)
        {
            this.AirplaneName =airplaneName;

        }

        public int _distanceInKm
        {
            get
            {
                return _int;
            }
            set
            {
                if(value>_int)
                 Notify();
                 _int = value;

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
       public  void Notify()
       {
           _observer.ForEach(x=> x.Update());
       }
    }
    //concrete subject
    public interface ISubject
    {
        void Subscribe(Observer observer);
        void UnSubscribe(Observer observer);
        void Notify();
    }

    //observer
    public class Observer:IObserver
    {
        public string ObserverName { get; set; }
      public Subject _subject { get; set; }
        public Observer(string observerName,Subject subject )
        {
            this.ObserverName = observerName;
            this._subject = subject;
            
        }

        public void Update()
        {
            System.Console.WriteLine($" {ObserverName} at coördinates{_subject._distanceInKm}  is watching:{ _subject.AirplaneName}");
        }

    }

    //concrete observer
    public interface IObserver
    {
        void Update();

    }

    public class Client
    {
        public Client()
        {
            Subject _subject = new Subject("XZJ São Paulo");
            Observer _observer1 = new Observer("Zaventem",_subject);
            _subject.Subscribe(_observer1);
            Observer _observer2 = new Observer("shiphol",_subject);
            _subject.Subscribe(_observer2);

            _subject._distanceInKm = 200;
           // _subject._distanceInKm++;
        }
    }


}
