using System;
using System.Collections.Generic;

namespace ConsoleBuilder
{
    //IBuilder
    public interface IConsoleBuilder
    {
         void BuildCover ();
         void BuildMotherBoard();
         void BuildControl();

         Console GetConsole();
    }

    //concrete builder

    public class ConsoleBuilder:IConsoleBuilder
    {
         Console console = new Console(); 

         public void BuildCover()
         {
              console.Cover += "building the cover";
         }
         public void BuildMotherBoard()
         {
              console.MotherBoard += "building the motherboard";
         }

     	public void BuildControl()
          {
               console.Controle += "building the controle";           
          }
          public Console GetConsole()
          {
               return console;
          }

    }

    //product 

     public class Console
    {
         public string Cover { get; set; }
         public string MotherBoard { get; set; }
         public string  Controle { get; set; }

     public void ShowInfo()
     {
          System.Console.WriteLine($"cover : {Cover}");
          System.Console.WriteLine($"motherboard: {MotherBoard}");
          System.Console.WriteLine($"controle : {Controle}");
     }

    
    }

    // director
    public class Director
    {
         private readonly IConsoleBuilder _consoleBuilder;
         public Director(IConsoleBuilder consoleBuilder)
         {
              this._consoleBuilder = consoleBuilder;
         }

         public void CreateConsole()
         {
              _consoleBuilder.BuildControl();
              _consoleBuilder.BuildCover();
              _consoleBuilder.BuildMotherBoard();
         }
         public Console GetConsole()
         {
              return _consoleBuilder.GetConsole();
         }

    }


    //client class
    public class Client
    {
         public Client()
         {
              Director d = new Director(new ConsoleBuilder());
              d.CreateConsole();
              var console = d.GetConsole();
              console.ShowInfo();
         
         }
    }
}