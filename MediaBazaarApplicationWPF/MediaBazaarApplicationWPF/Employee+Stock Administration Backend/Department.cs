using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApplicationWPF
{
    public class Department
    {
        #region variables + properties

        private EmployeeManager employeeManager;
        private string departmentId;
        private string name;
        private string address;
        List<Employee> employees;

        public List<Employee> Employees
        {
            get { return this.employees; }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    address = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    name = value;
            }
        }

        public string DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        #endregion
        #region Constructors
        public Department(string name, string address, string departmentID)
        {
            if (name.Length == 0 && address.Length == 0)
                throw new InvalidEntryException("Please provide the needed details for the department!");

            this.name = name;
            this.address = address;
            this.departmentId = departmentID;
            employees = new List<Employee>();
            employeeManager = new EmployeeManager();
        }

        #endregion
        #region Methods

        public override string ToString()
        {
            return $"{this.Name} on {this.Address}";
        }

        public Employee GetEmployee(string userID)
        {
            foreach (Employee employee in Employees)
                if (employee.UserID == userID)
                    return employee;
            return null;
        }

        public void RemoveEmployee(string userID)
        {
            foreach (Employee e in employees)
                if (e.UserID == userID)
                {
                    employeeManager.RemoveEmployee(e);
                    employees.Remove(e);
                    break;
                }
        }

        public void AssignEmployeeTo(Employee employee, string newDepartmentId)
        {
            if (!employees.Exists(e => e.UserID == employee.UserID))
            {
                employee.DepartmentID = newDepartmentId;
                employeeManager.UpdateEmployee(employee);
                employees.Remove(employee);
            }
        }
        #endregion
    }
}

