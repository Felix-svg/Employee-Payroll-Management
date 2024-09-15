using System;
using System.Collections.Generic;

namespace EmployeePayrollManagement;

class Program
{
    static void Main(string[] args)
    {
        bool manage = false;
        do
        {
            Employee employee = new();
            MainMenu(employee);
            Console.WriteLine("Do you want to continue? (Y/N)");
            string userChoice = Console.ReadLine().ToUpper().Trim();

            if (userChoice == "Y")
            {
                manage = true;
            }

        } while (manage == true);
    }

    static public List<Employee> employees = new List<Employee>();

    static void MainMenu(Employee employee)
    {
        Console.WriteLine("Choose an option");
        Console.WriteLine("1. Registration");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Exit");

        string userChoice = Console.ReadLine();
        if (userChoice == "1")
        {
            Registration(employee);
        }
        else if (userChoice == "2")
        {
            Login(employee);
        }
        else if (userChoice == "3")
        {
            Environment.Exit(1);
        }
    }

    static void SubMenu(Employee employee)
    {
        Console.WriteLine("Choose an option");
        Console.WriteLine("1. Calculate salary");
        Console.WriteLine("2. Display my details");
        Console.WriteLine("3. Exit");

        string userChoice = Console.ReadLine();
        if (userChoice == "1")
        {
            CalculateSalary(employee);
        }
        else if (userChoice == "2")
        {
            DisplayDetails(employee);
        }
        else if (userChoice == "3")
        {
            MainMenu(employee);
        }
    }

    static void Registration(Employee employee)
    {
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter role");
        string role = Console.ReadLine();
        Console.WriteLine("Enter work location");
        string workLocation = Console.ReadLine();
        Console.WriteLine("Enter team name");
        string teamName = Console.ReadLine();
        Console.WriteLine("Enter date of joining (dd/MM/yyyy)");
        DateTime dateOfJoining = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.WriteLine("Enter number of working days");
        int numberOfWorkingDays = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter numberof leave taken");
        int numberOfLeaveTaken = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter gender");
        string gender = Console.ReadLine();

        employee.EmployeeId = GenerateEmployeeId(employee);
        employee.EmployeeName = name;
        employee.Role = role;
        employee.WorkLocation = workLocation;
        employee.TeamName = teamName;
        employee.DateOfJoining = dateOfJoining;
        employee.NumberOfWorkingDays = numberOfWorkingDays;
        employee.NumberOfLeaveTaken = numberOfLeaveTaken;
        employee.Gender = gender;

        Console.WriteLine(GenerateEmployeeId(employee));
        employees.Add(employee);
    }

    static string validatedId;
    static string Login(Employee employee)
    {
        Console.WriteLine("Enter ID");
        string employeeId = Console.ReadLine();

        foreach (Employee employee1 in employees)
        {
            if (employeeId == employee1.EmployeeId)
            {
                validatedId = employeeId;
                SubMenu(employee);
            }
            else
            {
                Console.WriteLine("User Invalid ID");
            }
        }
        return validatedId;
    }

    static void CalculateSalary(Employee employee)
    {
        int salary = 0;
        string id = validatedId;
        foreach (Employee employee1 in employees)
        {
            if (employee1.EmployeeId == id)
            {
                salary = (employee1.NumberOfWorkingDays - employee1.NumberOfLeaveTaken) * 500;
            }
        }
        Console.WriteLine($"Your salary is {salary}");
    }

    static void DisplayDetails(Employee employee)
    {
        string id = validatedId;
        foreach (Employee employee1 in employees)
        {
            if (employee1.EmployeeId == id)
            {
                Console.WriteLine($"Employee ID: {employee1.EmployeeId}\nName: {employee1.EmployeeName}\nRole: {employee1.Role}\nTeam: {employee1.TeamName}\nJoined: {employee1.DateOfJoining}");
            }
        }
    }

    static string GenerateEmployeeId(Employee employee)
    {
        employee.EmployeeId = $"SF100{1 + employees.Count}";
        return employee.EmployeeId;
    }
}