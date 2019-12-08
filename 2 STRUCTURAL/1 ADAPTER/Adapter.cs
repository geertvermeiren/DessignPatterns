using System;
//ITarget: This is the interface which is used by the client to achieve functionality.<o:p>
//Adaptee: This is the functionality which the client desires but its interface is not compatible with the client.<o:p>
//Client: This is the class which wants to achieve some functionality by using the adaptee’s code.
//Adapter: This is the class which would implement ITarget and would call the Adaptee code which the client wants to call.



namespace GOF
{

    public interface ITarget
    {
        string GetRequest();
    }

    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "this is a specific request";
        }
    }


    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
            
        }

        public string GetRequest()
        {
            return $"this is a {this._adaptee.GetSpecificRequest()}";
        }



    }
}