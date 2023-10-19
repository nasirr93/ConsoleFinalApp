using GarageConsoleFinalApp.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GarageConsoleFinalApp
{
    internal class Employee
    {
        private static int no = 1000;
        private double salary;
        private string position;
        //public Employee(string fullname,string position,double salary, Department department, EmployeeType employeetype)
        //{
        //    //empNo = EmployeeNo(department);
        //    //Fullname = CheckFullname(fullname);
        //    //Position = position;
        //    //Department = department;
        //    //EmployeeType = employeetype;
        //    //Salary = salary;
           
        //}

        public Employee()
        {

        }

        private string empno;
        public string empNo 
        { 
            get { return empno; }
            set
            {
                if (EmployeeNo(value))
                {
                    empno= value;
                }
            }
        }

        private string fullname;
        public string Fullname 
        { get { return fullname; }
            set
            {
                if (value.Length >= 2 && CheckFullname(value))
                    fullname = value;
                else
                    throw new ArgumentException();
            }
        }
        public string Position
        {
            get { return position; }
            set
            {
                if (value.Length >= 2 && CheckPosition(value))
                    position = value;
                else
                    throw new ArgumentException("Error.. Try again !");
            }
        }
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value >= 250)
                    salary = value;
                else
                    throw new ArgumentException("Error.. Try again !");
            }
        }
        public Department Department { get; set; }  
        public EmployeeType EmployeeType { get; set; }


        private bool EmployeeNo(string departmentNo)
        {
            try
            {
                if (departmentNo.Length > 5)
                {
                    if (departmentNo == Department.IT.ToString().Substring(0, 2).ToUpper())
                    {
                        no++;
                    }
                    else if (departmentNo == Department.FINANCE.ToString().Substring(0, 2).ToUpper())
                    {
                        no++;
                    }
                    else if (departmentNo == Department.MARKETING.ToString().Substring(0, 2).ToUpper())
                    {
                        no++;
                    }

                    string text = departmentNo.ToString().Substring(0, 2);
                    int empNo = no++;
                    string join = $"{text}{empNo}";
                    return true;
                }
                
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }
            return false;
        }

        private bool CheckFullname(string fullname)
        {
            try
            {
                string[] checkName = fullname.Split(' ');

                if (checkName.Length >= 2)
                {
                    for (int i = 0; i < checkName.Length; i++)
                    {
                        string word = checkName[i];

                        if (word.Length < 3 && word.Any(Char.IsDigit))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return false;
        }

        private bool CheckPosition(string position)
        {
            try
            {
                if (position.Length>=2)
                {
                    for (int i = 0; i < position.Length; i++)
                    {
                        if (char.IsLetter(position[i]) && !char.IsDigit(position[i]))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); 
            }
            return false;
        }

     

    }

    
}
