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
    

        public Employee()
        {

        }

        private string empno;
        public string empNo 
        { 
            get { return empno; }
            set
            {
                if (value.Length>=2)
                {
                    empno = EmployeeNo(value);
                }
                else 
                {
                    Console.WriteLine("Xeta bas verdi");
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
        private Department department;
        public Department Department
        {
            get { return department; }
            set
            {
                department = value;
            }
        }  

        public EmployeeType EmployeeType { get; set; }


        private string EmployeeNo(string department)
        {

            string departmentNo = department.Substring(0, 2).ToUpper();

            try
            {
                if (departmentNo == department.ToString().Substring(0, 2).ToUpper())
                {
                    if (departmentNo == Department.IT.ToString().Substring(0, 2).ToUpper())
                    {
                        departmentNo = "IT";
                    }
                    else if (departmentNo == Department.Finance.ToString().Substring(0, 2).ToUpper())
                    {
                        departmentNo = "Fİ";
                    }
                    else if (departmentNo == Department.Marketing.ToString().Substring(0, 2).ToUpper())
                    {
                        departmentNo = "MA";
                    }
                    int empNo = no++;
                    string text = departmentNo.ToString().Substring(0, 2);
                    string join = $"{text}{empNo}";
                    return join;
                }
                
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }
            
            throw new ArgumentException();
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
