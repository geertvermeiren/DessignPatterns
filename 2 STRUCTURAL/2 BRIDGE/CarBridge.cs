using System;

//split business logic into separate classes and develop independently
//step 1: use the basicplatfron
//step 2: differentiate  => sedan,suv

namespace CarBridge
{
    //ABSTRACTION
    public abstract class BasicCarPlatform
    {
       protected IAssemble _assemblecar;

        public abstract void BuildCar();
    }

    //EXTENDED/REDEFINED ABSTRACTION 1 : ABSTRACTION

    public class BuildSedan:BasicCarPlatform
    {
        public override void BuildCar()
        {
          _assemblecar.Assemble("SEDAN");
        }

    }

    //EXTENDED/REDIFINED ABSTRACTION 2: ABSTRACTION 

    public class BuildSUV:BasicCarPlatform
    {
        public override void BuildCar()
        {
            _assemblecar.Assemble("SUV");
        }
    }


    //IMPLEMENTATION

    public interface IAssemble
    {
        void Assemble(string typeOfCar);

    }


    //CONCRETE IMPLEMENTATIONA : IMPLEMENTATION

    public class VolksWagenSedan:IAssemble
    {
        public void Assemble(string type)
        {
            System.Console.WriteLine($"building a {this.GetType().Name}: {type}");
        }
    }

    //CONCRETE IMPLEMENTATIONB: IMPLEMENTATION

    public class VoklksWagenSUV:IAssemble
    {
        public void Assemble(string type)
        {
            System.Console.WriteLine($"building a {this.GetType().Name}: {type}");
           
        }
    }


    //CLIENT

    public class AccessClient
    {
        public void ClientCode()
        {

        }
    }



}

