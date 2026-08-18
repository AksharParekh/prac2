using System;

namespace EMP_Payroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********************");
            Console.WriteLine("EMPLOYEE PAYROLL SYSTEM");
            Console.WriteLine("*********************");

            Console.WriteLine("Select Employee Type");
            Console.WriteLine("1. FULL-TIME");
            Console.WriteLine("2. PART-TIME");

            Console.Write("Enter Your Choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());

            Employee e = null;
            IPayroll p = null;

            if (ch == 1)
            {
                e = new FullTimeEmp();
                p = (IPayroll)e;
            }
            else if (ch == 2)
            {
                e = new PartTimeEmp();
                p = (IPayroll)e;
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
                return;
            }

            e.AcceptDetails();
            e.Display();
            p.CalcSalary();

            Console.ReadKey();
        }

        interface IPayroll
        {
            void CalcSalary();
        }

        class Employee
        {
            public int Id;
            public string Name;
            public double BasicSalary;

            public void AcceptDetails()
            {
                Console.Write("Enter Employee ID : ");
                Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Name : ");
                Name = Console.ReadLine();

                Console.Write("Enter Basic Salary : ");
                BasicSalary = Convert.ToDouble(Console.ReadLine());
            }

            public void Display()
            {
                Console.WriteLine("\nEmployee Details");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Employee ID      : " + Id);
                Console.WriteLine("Employee Name    : " + Name);
                Console.WriteLine("Basic Salary     : " + BasicSalary);
            }
        }

        class FullTimeEmp : Employee, IPayroll
        {
            public void CalcSalary()
            {
                double da = BasicSalary * 0.20;
                double hra = BasicSalary * 0.35;
                double ma = BasicSalary * 0.10;
                double pf = BasicSalary * 0.12;

                double netSalary = (BasicSalary + da + hra + ma) - pf;

                Console.WriteLine("\nEmployee Type : FULL-TIME");
                Console.WriteLine("DA            : " + da);
                Console.WriteLine("HRA           : " + hra);
                Console.WriteLine("Medical Allow.: " + ma);
                Console.WriteLine("PF Deduction  : " + pf);
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Net Salary    : " + netSalary);
            }
        }

        class PartTimeEmp : Employee, IPayroll
        {
            public void CalcSalary()
            {
                Console.WriteLine("\nEmployee Type : PART-TIME");
                Console.WriteLine("Net Salary    : " + BasicSalary);
            }
        }
    }
}