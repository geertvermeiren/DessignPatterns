using System;
//facade= reduced interface.. to complex operations.. 

namespace RobotFacade
{
    // facade
    public class Facade
    {
        RobotHardWare _robotHardware;
        RobotSoftware _robotSoftware;
        public Facade(RobotHardWare robotHardWare,RobotSoftware RobotSoftware)
        {
            this._robotHardware = robotHardWare;
            this._robotSoftware = RobotSoftware;
        }

        public string Operate()
        {
            string result ; 

            result = "start robot hardawrae \n";
            result += _robotHardware.Operation1();
            result += _robotHardware.Operation2();
            result = "start sofware \n";
            result += _robotSoftware.Operation2();
            result += _robotSoftware.Operation3();
            return result;
            
        }                   
        
    }

    //complex subsystem 1

    public class RobotHardWare
    {

         public string Operation1()
        {
            return this.GetType().Name +"operation 1" ;
        }
        public string Operation2()
        {
            return this.GetType().Name + "operation 2";
        }
        public string Operation3()
        {
            return  this.GetType().Name+ "operation 3";
        }
    }



    

    //complex subsystem 2
    public class RobotSoftware
    {
        public string Operation1()
        {
            return this.GetType().Name +"operation 1" ;
        }
        public string Operation2()
        {
            return this.GetType().Name + "operation 2";
        }
        public string Operation3()
        {
            return  this.GetType().Name+ "operation 3";
        }

    }
    //ClientAccess

    public class ClientAccess
    {

        public static void ClientCode(Facade facade)
        {
            System.Console.WriteLine(facade.Operate());

        }

    }

    //Client
    public class Client
    {
        public Client()
        {
            var rh = new RobotHardWare();
            var rs = new RobotSoftware();
            var f = new Facade(rh,rs);
            ClientAccess.ClientCode(f);
        }
    }

}