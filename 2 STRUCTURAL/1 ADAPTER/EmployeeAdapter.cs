using System;
using System.Collections.Generic;

//https://riptutorial.com/csharp/example/30087/adapter-design-pattern


//wo mutually incompatible interfaces communicate with each other.

namespace EmployeeAdapter
{
    /// <summary>
/// Adaptee: This is the functionality which the client desires but its interface is not compatible with the client.
/// </summary>
    //Adaptee
    public class CompanyEmplyees
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];

            employees[0] = new string[] { "100", "Deepak", "Team Leader" };
            employees[1] = new string[] { "101", "Rohit", "Developer" };
            employees[2] = new string[] { "102", "Gautam", "Developer" };
            employees[3] = new string[] { "103", "Dev", "Tester" };

            return employees;
        }
    }
    
    //ITarget

    public interface ITarget
    {
        List<string> GetEmployeeList();
    }
    

    //Adapter

    // public class Adapter:CompanyEmplyees, ITarget
    // {

    //     public List<string> GetEmployees()
    //     {
    //         public List<string> employeeList = new List<string>();





    //     }



    // }


    //client

    /// <summary>
/// Client: This is the class which wants to achieve some functionality by using the adaptee’s code (list of employees).
/// </summary>
    public class ThirdPartyBillingSystem
    {
        /* 
        * This class is from a thirt party and you do'n have any control over it. 
        * But it requires a Emplyee list to do its work
        */

        private ITarget employeeSource;

        public ThirdPartyBillingSystem(ITarget employeeSource)
        {
            this.employeeSource = employeeSource;
        }

        public void ShowEmployeeList()
        {
            // call the clietn list in the interface
            List<string> employee = employeeSource.GetEmployeeList();

            Console.WriteLine("######### Employee List ##########");
            foreach (var item in employee)
            {
                Console.Write(item);
            }

        }
    }


}