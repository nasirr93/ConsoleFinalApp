using GarageConsoleFinalApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleFinalApp
{
    internal class University
    {
        private string name;
        private int workerLimit;
        private double salaryLimit;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 2)
                    name = value;
                else
                    throw new ArgumentException("Error.. Try again !");
            }
        }

        bool chechkName(string name)
        {
            try
            {
                if (name.Length >= 2)
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (Char.IsLetter(name[i]) && !Char.IsDigit(name[i]))
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public int WorkerLimit
        {
            get { return workerLimit; }
            set
            {
                if (value >= 1)
                    workerLimit = value;
                else
                    throw new ArgumentException("Error.. Try again !");
            }
        }

        public double SalaryLimit
        {
            get { return salaryLimit; }
            set
            {
                if (value >= 250)
                    salaryLimit = value;
                else
                    throw new ArgumentException("Error.. Try again !");
            }
        }


        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get { return _employees; }
        }

        private List<Student> _students;
        public List<Student> Students
        {
            get { return _students; }
        }

        public University(string name, int workerLimit, double salaryLimit)
        {
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
            _employees = new List<Employee>();
            _students = new List<Student>();
        }


        public void CalcSalaryAverage() // Unideki isciler ucun maas ortalama
        {
            double totalSum = 0;

            if (_employees != null && _employees.Count > 0)
            {
                for (int i = 0; i < _employees.Count; i++)
                {
                    totalSum += _employees[i].Salary;
                }
                double empAvarage = totalSum / _employees.Count;

                Console.WriteLine($"Employees Salary : {empAvarage}");
            }
            else
            {
                Console.WriteLine("Sistemde isci yoxdur");
            }
        }
        public void CalcAllStudentsAverage() //Unideki telebeler ucun point ortalama
        {
            double totalSum = 0;
            if (_students != null && _students.Count > 0)
            {
                for (int i = 0; i < _students.Count; i++)
                {
                    totalSum += _students[i].Point;
                }
                double allStAvarage = totalSum / _students.Count;

                Console.WriteLine($"All Student Avarage : {allStAvarage}");
            }
            else
            {
                Console.WriteLine("Sistemde telebe yoxdur");
            }
        }
        public void CalcGroupStudentsAverage(GroupType groupType) // Qrupdaki telebeler ucun point ortalama
        {
            double totalPoint = 0;
            var groupStudents = _students.FindAll(student => student.GroupType == groupType);

            if (groupStudents != null && groupStudents.Count > 0)
            {

                foreach (var student in groupStudents)
                {
                    totalPoint += student.Point;
                }
                double grStAvarage = totalPoint / groupStudents.Count;

                Console.WriteLine($"Gruop Tudent Avarage : {grStAvarage}");
            }
            else
            {
                Console.WriteLine("Groupda telebe yoxdur");
            }

        }
        public void AddEmployee(Employee employee)
        {
            if (_employees.Count < WorkerLimit && !_employees.Exists(e => e.Position == employee.Position))
                _employees.Add(employee);

            else
                Console.WriteLine("Employee elave etmek mumkun olmadi");
        }
        public void AddStudent(Student student)
        {
            if (_students.Count < WorkerLimit && !_students.Exists(x => x.GroupNo == student.GroupNo))
                _students.Add(student);
            else
                Console.WriteLine("Student elave etmek mumkun olmadi");
        }
        public void EmployeeUpdate(string employeeNo, double salary, string position)
        {
            Employee empUpadte = _employees.Find(e => e.empNo == employeeNo);

            if (empUpadte != null)
            {
                empUpadte.Salary = salary;
                empUpadte.Position = position;
                Console.WriteLine("Employee Updated olundu !");
            }
            else

                Console.WriteLine("Employee Not Found");
        }
        public void StudentUpdate(string eksGroupNo, string yeniGroupNo, double point)
        {
            Student stUpdate = _students.Find(s => s.GroupNo == eksGroupNo);

            if (stUpdate != null)
            {
                stUpdate.Point = point;
                stUpdate.GroupNo = yeniGroupNo;
                Console.WriteLine("Student Updated olundu !");
            }
            else
                Console.WriteLine("Student Not Found");
        }
        public void DeleteEmployee(string employeeNo)
        {
            var dltEmployee = _employees.Find(e => e.empNo == employeeNo);

            if (dltEmployee != null)
            {
                _employees.Remove(dltEmployee);
                Console.WriteLine("Employee silindi");
            }
            else
                Console.WriteLine("Not deleted");
        }

        public void ShowStudent()
        {

            if (_students != null && _students.Count > 0)
            {
                foreach (var item in _students)
                {
                    Console.WriteLine($"(Fullname: {item.FullName} \r\n GroupType {item.GroupType} \r\n GroupNo {item.GroupNo} \r\n Point {item.Point}");
                }
            }
            else
            {
                Console.WriteLine("Sistemde telebe yoxdu");
            }
        }

        public void ShowEmployee()
        {
            if (_employees != null && _employees.Count > 0)
            {
                foreach (var item in _employees)
                {
                    Console.WriteLine($"(Fullname: {item.Fullname} \r\n Department: {item.Department} \r\n GroupNo: {item.empNo} \r\n Position: {item.Position} \r\n Salary: {item.Salary} \r\n EmployeeType: {item.EmployeeType}");
                }
            }
            else
            {
                Console.WriteLine("Sistemde isci yoxdu");
            }
        }

        public void showEmployeeNo(string empno)
        {
            var employeeNo = _employees.FindAll(employees => employees.empNo == empno);

            if (employeeNo != null && employeeNo.Count > 0)
            {
                foreach (var item in employeeNo)
                {
                    Console.WriteLine($"Fullname : {item.Fullname} \r\n Salary : {item.Salary} \r\n Position : {item.Position} \r\n Department : {item.Department}");
                }
            }
            else
            {
                Console.WriteLine("Error.. Try again !");
            }
        }

        public void ShowDepartmentEmployee(Department department)
        {
            var departmentEmployee = _employees.FindAll(employees => employees.Department == department);

            if (departmentEmployee != null && departmentEmployee.Count > 0)
            {
                foreach (var item in departmentEmployee)
                {
                    Console.WriteLine($"No : {item.empNo} \r\n Fullname : {item.Fullname} \r\n Position : {item.Position} \r\n Salary : {item.Salary}");
                }
            }
            else
            {
                Console.WriteLine("Deparmentde isci yoxdur");
            }
        }


        public void SearchEmploye(EmployeeType emptype)
        {

            var foundEmployees = _employees.FindAll(employees => employees.EmployeeType == emptype);


            if (foundEmployees != null && foundEmployees.Count > 0)
            {
                Console.WriteLine("The result for Employees: ");
                foreach (var employee in foundEmployees)
                {
                    Console.WriteLine(employee.Fullname);
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
        public void SearchStudent(GroupType grtype)
        {
            var foundStudents = _students.FindAll(student => student.GroupType == grtype);

            if (foundStudents != null && foundStudents.Count > 0)
            {
                Console.WriteLine("The result for Students :");
                foreach (var student in foundStudents)
                {
                    Console.WriteLine(student.FullName);
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }


    }
}
