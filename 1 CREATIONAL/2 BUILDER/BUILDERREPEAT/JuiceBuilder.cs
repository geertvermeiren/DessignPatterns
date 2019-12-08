using System;
using System.Collections.Generic;

namespace JuiceBuilder
{
    //ibuilder
    public interface IJuiceBuilder
    {
         void AddFruit ();
         void MixFruit();
         Juice GetJuice();
    }

    //concrete builder
    public class ConcreteBuilder:IJuiceBuilder
    {
        Juice _juice = new Juice();

        public void AddFruit()
        {
            _juice.fruit = "adding all kinds of fruits";
        }
        public void MixFruit()
        {
            _juice.mixer = "mixing fruit";
        } 

        public Juice GetJuice()
        {
            return _juice;
        }

    }


    //product
    public class Juice
    {
        public string fruit { get; set; }
        public string  mixer { get; set; }
        public void ShowInfo()
        {
            System.Console.WriteLine($"fruit; {fruit}");
            System.Console.WriteLine($"fruit; {mixer}");
        }
    }

    //director

    public class Director
    {
        IJuiceBuilder _builderJuice;
        public Director(IJuiceBuilder juiceBuilder)
        {
            this._builderJuice = juiceBuilder;
        }

        public void MakeJuice()
        {
            _builderJuice.AddFruit();
            _builderJuice.MixFruit();
        }

        public Juice GetJuice()
        {
            return _builderJuice.GetJuice();
        }

    }

     public class name
     {
     
     
     
    }
    //client class
    public class Client
    {
         public Client()
         {
          Director d = new Director(new ConcreteBuilder());
          d.MakeJuice();
          Juice j = d.GetJuice();
          j.ShowInfo();
         }
         
    }
}