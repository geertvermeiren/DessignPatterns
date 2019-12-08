using System;

//computer platform abstranction: => motherboard, networkdconnection etc etc hardware design
//extended abstractino small vs large motherboard
// implementation => gsm vs laptop

namespace ComputerBridge
{
  // abstractor
  public abstract class HardWareDesign
  {
      public IHardwareAssembly _hardwareAssembly;

      public abstract void Design();

  }


  // extended abstraction A

  public class LargeDesign: HardWareDesign
  {
      public override void Design()
      {
          _hardwareAssembly.Assemble("large motherboard");
      }
  }

  //extended abstraction B 

  public class SmallDesign:HardWareDesign
  {
      public override void Design()
      {
          _hardwareAssembly.Assemble("motherboard");

      }
  }

  // implementation 

  public interface IHardwareAssembly
  {
      void Assemble(string type);
  }

  //concxrete implementation A: implementation
 
  public class MobilePhoneDesign:IHardwareAssembly
  {
      public void Assemble(string type)
      {
          System.Console.WriteLine($"the {this.GetType().Name}  based on  type: {type} is designed");
      }
  }

  //concrete implementation B: implementation

  public class LaptopDesign:IHardwareAssembly
  {
      public void Assemble(string type)
      {
          System.Console.WriteLine($"the {this.GetType().Name} type: {type} is designed");
      }
  }

  //client 

  public class Client
  {
      public Client()
      {
          HardWareDesign _hardwareDesign = new SmallDesign();
          _hardwareDesign._hardwareAssembly = new MobilePhoneDesign();
          _hardwareDesign.Design();

          _hardwareDesign._hardwareAssembly = new LaptopDesign();
          _hardwareDesign.Design();
      }
  }






}


