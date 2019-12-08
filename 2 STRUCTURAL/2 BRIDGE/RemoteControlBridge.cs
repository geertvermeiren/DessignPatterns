using System;
using System.Collections.Generic;

namespace RemoteControlBridge
{
    //abstraction
    public class RemoteControl
    {
        protected IDevice _device;
        public RemoteControl(IDevice device)
        {
            this._device = device;
        }

        public void VolumeDown()
        {
             _device.SetVolume(_device.GetVolume()-10);

        }
        public void VolumeUp()
        {
           _device.SetVolume(_device.GetVolume()+10);
        }

        public int GetVolume()
        {
           return _device.GetVolume();
        }
    }

    //refined abstraction
     public class name
    {
     
     
     
    }
   //interface
   public interface IDevice
   {
       
        int GetVolume();
        
        void SetVolume(int percentage);

        int GetChannel();
        void SetChannel(int channel);
   }
   //concrete interface

   public class TV :IDevice
   {
       public int _percentage;
       public int _channel;
      
       public int GetVolume()
       {
         
         return _percentage;
       }
       public void SetVolume(int percentage)
       {
           this._percentage = percentage;
       }

       public int GetChannel()
       {
           return _channel;
       }

       public void SetChannel(int channel)
       {
           this._channel = channel;

       }


   }




    //client class
    public class Client
    {
         public Client()
         {
             TV _tv = new TV();
             RemoteControl rc = new RemoteControl(_tv);
             rc.VolumeUp();
             rc.VolumeUp();
             rc.VolumeUp();
             System.Console.WriteLine(rc.GetVolume());
             
         
         }
    }
}