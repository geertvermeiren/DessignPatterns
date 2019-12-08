using System;

namespace LawyerProxy
{
 //the  subject

 public interface IPlaintiff
 {
     void AskAmount(int amount);

     void GetConviction(float factor);

     void Receive();


 }

 //the real subject

 public class Plaintiff:IPlaintiff
 {
     private int _amount;
     
  
 public void AskAmount(int amount)
 {
     _amount = amount;

 }

     public void GetConviction(float factor)
     {
         _amount = Convert.ToInt32(_amount * factor);
     }

     public void Receive()
     {
         System.Console.WriteLine($" i have receive : {_amount}");
     }
 }


 //proxy 

 public class LawyerProxy:IPlaintiff
 {
       private int _amount;
       Plaintiff _plaintiff = new Plaintiff();
     
  
        public void AskAmount(int amount)
        {
            _amount = amount;

        }

     public void GetConviction(float factor)
     {
         _amount = Convert.ToInt32(_amount * factor);
     }

     public void Receive()
     {
         System.Console.WriteLine("the lawyer cannot receive");
         _plaintiff.Receive();
      
     }
 }

 public class Client
 {
     public Client()
     {
         LawyerProxy lp = new LawyerProxy();
         lp.AskAmount(500000);
         float x = 1F;
         lp.GetConviction(x);
         lp.Receive();
     }
 }


}