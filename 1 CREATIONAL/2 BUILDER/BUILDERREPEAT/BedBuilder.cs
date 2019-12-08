using System;
using System.Collections.Generic;

namespace BedBuilder
{
     //Ibuiler

     public interface IBedBuilder
     {
          void BuildBedFrame ();
          void BuildMatrass();

          Bed GetBed();

          
     }

     //concrete Builder

     public class ConcreteBedBuilder:IBedBuilder
     {
          Bed _bed = new Bed();

          public void BuildBedFrame()
          {
               _bed.BedFrame = "Build the bed";
          }
          public void BuildMatrass()
          {
               _bed.Matras = "Build the matrass";
          }



          public Bed GetBed()
          {
               return this._bed;
          }

     }

     public class Bed
     {
      public string Matras { get; set; }
      public string BedFrame { get; set; }
          public void Showinfo()
          {
               System.Console.WriteLine($"Bedframe: {BedFrame}");
               System.Console.WriteLine($"Matras: {Matras}");
          }
     }

     //product

     //directory
     public class Director
     {
          private readonly ConcreteBedBuilder _concreteBedBuilder;

          public Director(ConcreteBedBuilder concreteBedBuilder)
          {
               this._concreteBedBuilder = concreteBedBuilder;
          }

          public void BuildBed()
          {
               _concreteBedBuilder.BuildBedFrame();
               _concreteBedBuilder.BuildMatrass();
          }

          public Bed GetBed()
          {
               return _concreteBedBuilder.GetBed();
          }
     }

    //client class
    public class Client
    {
         public Client()
         {
              var d = new Director(new ConcreteBedBuilder());
              d.BuildBed();
              var bed = d.GetBed();
              bed.Showinfo();
         
         }
    }
}