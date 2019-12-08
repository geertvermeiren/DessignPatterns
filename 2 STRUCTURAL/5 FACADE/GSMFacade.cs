using System;
namespace GSMFacade
{
    // facade

    public class Facade
    {
        MotherBoard _motherBoard;
        NetWork _netWork;

        public Facade(MotherBoard motherBoard, NetWork netWork)
        {
            this._motherBoard = motherBoard;
            this._netWork = netWork;

        }

        public string Operation()
        {
            string result = "start of mb \n";
            result += _motherBoard.Operation1();
            result += _motherBoard.Operation3();
        
            result += _netWork.Operation1();
            result += _netWork.Operation2();
            return result;
        }




    }

    //multiple complex subsystems 

    public class MotherBoard
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

    public class NetWork
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

    //clientCode 

    public class AccessClient
    {
        public static void ClientCode(Facade facade)
        {
            System.Console.WriteLine(facade.Operation());

        }
    }

    //client

    public class Client
    {
        public Client()
        {
            MotherBoard mb = new MotherBoard();
            NetWork nw = new NetWork();

            Facade f = new Facade(mb,nw);
            AccessClient.ClientCode(f);
           //  System.Console.WriteLine(f.Operation());
        }
    }

    
}