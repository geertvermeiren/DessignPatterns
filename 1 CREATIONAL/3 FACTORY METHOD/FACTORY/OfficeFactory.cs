using System;
using System.Collections.Generic;

namespace OfficeFactory
{
    //abstract creator
    public abstract class Creator
    {
        public abstract IOfficeEquipment CreateDesk();
        public abstract IOfficeEquipment CreeteChair();
    }

    //concrete Creator

    public class DomoCreator:Creator
    {
        public override IOfficeEquipment CreateDesk()
        {
            return new Desk();

        }
        public override IOfficeEquipment CreeteChair()
        {
            return new Chair();
        }
    }

    //product
    public interface IOfficeEquipment
    {
         string Operate ();
    }

    //concrete product
    public class Desk: IOfficeEquipment
    {
        public string Operate()
        {
            return $"building {this.GetType().Name}";
        }
    }

    public class Chair:IOfficeEquipment
    {
        public string Operate()
        {
            return $"building {this.GetType().Name}";
        }

    }

    
    //client class
    public class Client
    {
         public Client()
         {
          ClientMethod(new DomoCreator());
         }
         public void ClientMethod(Creator creator)
         {
            var desk = creator.CreateDesk();
            var chair = creator.CreeteChair();
           System.Console.WriteLine(desk.Operate());
           System.Console.WriteLine(chair.Operate());

         }
    }
}