using GarageConsoleFinalApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsoleFinalApp
{
    internal class Student
    {
        private static int No = 100;
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
                if (checkGroupNo(value))
                {
                    groupNo = value;
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

        private bool checkGroupNo(string groupNum)
        {
            try
            {
                if (groupNum.Length > 3)
                {
                    char firstChar = char.ToUpper(groupNum[0]);

                    if (
                         firstChar == GroupType.Programming.ToString()[0]
                      || firstChar == GroupType.Design.ToString()[0] 
                      || firstChar == GroupType.System.ToString()[0])
                    {
                        string text = firstChar.ToString();
                        int stNo = No++;
                        string join = $"{text}{stNo}";
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }

            return false;
        }

    }
}
