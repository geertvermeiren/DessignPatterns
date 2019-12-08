using System;
using System.Collections.Generic;


namespace EmployeeAdapter
{

   public class Emplpyees
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

        public Emplpyees()
        {         

                var e = GetEmployees().GetEnumerator();
                Console.WriteLine( "The Array contains the following values:" );
                int i = 0;
                while(e.MoveNext() && e.Current != null)
                { i++;
                    System.Console.WriteLine("counting {0} {1}" , i,e.Current );
                }
       

        }

        public  void Employee2()
        {
            var emp = GetEmployees();
            List<string> employeeList = new List<string>();

            foreach(var employee in emp)
            {
            employeeList.Add(employee[0]);
            employeeList.Add(",");
            employeeList.Add(employee[1]);
            employeeList.Add(",");
            employeeList.Add(employee[2]);
            employeeList.Add("\n");

            }


        }

   }
   

   
}