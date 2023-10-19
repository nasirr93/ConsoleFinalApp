using GarageConsoleFinalApp.Enums;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GarageConsoleFinalApp
{
    internal class Student
    {
        private static int no = 100;
        private string  fullname;
        public string FullName 
        { 
            get { return fullname; }
            set
            {

                if (value.Length >= 2 && CheckFullname(value))
                    fullname = value;
                else
                    throw new ArgumentException();
              
            }
        }
        public GroupType GroupType { get;  set; }

        private string groupNo;
        public string GroupNo
        { 
            get { return groupNo; }
            set
            {
                if (value.Length > 5)
                {
                    groupNo = checkGroupNo(value);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private double point;
        public double Point
        {
            get { return point; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    point = value;
                }
                else
                    throw new ArgumentException();
            } 
        }

       
      

        private bool CheckFullname(string fullname)
        {
            try
            {
                string[] checkName = fullname.Split(' ');

                if (fullname.Split(' ').Length >= 2)
                {
                    for (int i = 0; i < fullname.Split(' ').Length; i++)
                    {
                        string word = checkName[i];

                        if (word.Length < 3 || word.Any(Char.IsDigit))
                        {
                            return false; 

                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

               Console.WriteLine(ex.Message);
            }
            return false;
        }

        private string checkGroupNo(string group)
        {
            string groupNo = group.Substring(0, 1).ToUpper();

            try
            {
                if (groupNo == group.ToString().Substring(0, 1).ToUpper())
                {
                    if (groupNo == GroupType.Programming.ToString().Substring(0, 1).ToUpper())
                    {
                        groupNo = "P";
                    }
                    else if (groupNo == GroupType.Design.ToString().Substring(0, 1).ToUpper())
                    {
                        groupNo = "D";
                    }
                    else if (groupNo == GroupType.System.ToString().Substring(0, 1).ToUpper())
                    {
                        groupNo = "S";
                    }
                    int empNo = no++;
                    string text = groupNo.ToString().Substring(0, 1);
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

    }
}
