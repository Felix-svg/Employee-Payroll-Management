using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public string WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int NumberOfWorkingDays { get; set; }
        public int NumberOfLeaveTaken { get; set; }
        public string Gender { get; set; }

        public Employee()
        {

        }

        public Employee(string employeeId, string employeeName, string role, string workLocation, string teamName, DateTime dateOfJoining, int numberOfWorkingDays, int numberOfLeaveTaken, string gender)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            Role = role;
            WorkLocation = workLocation;
            TeamName = teamName;
            DateOfJoining = dateOfJoining;
            NumberOfWorkingDays = numberOfWorkingDays;
            NumberOfLeaveTaken = numberOfLeaveTaken;
            Gender = gender;
        }

    }
}