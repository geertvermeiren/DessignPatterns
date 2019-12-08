using System;
using System.Collections.Generic;
using Arr;

namespace Names
{

  // ITarget

  public interface ITarget
  {
      List<string> GetNames();
  }

  //adapter 

  public class Adapter: FamilyNames,ITarget
  {

      public List<string> GetNames()
      {
          List<string> vermeiren = new List<string>();
          string[] myNames = GetMyNames();

          foreach(var items in myNames)
          {
              System.Console.WriteLine(items);

              vermeiren.Add(items);

          }
        return vermeiren;

      }
  }


  //adaptee  : datafile 

  //client  : unmutable 

  public class Client
  {
      /* 
        * This class is from a thirt party and you do'n have any control over it. 
        * But it requires a Emplyee list to do its work
        */
        private ITarget _namesSource;

        public Client(ITarget namesSource)
        {
            _namesSource = namesSource;
        }
      public void DisplayNames()
      {      

        List<string> namesList = _namesSource.GetNames();

       //   System.Console.WriteLine("******DISPLAY NAMES***********");

          foreach(var item in namesList)
          {
              System.Console.WriteLine(item);

          }
      }
  }

    

}