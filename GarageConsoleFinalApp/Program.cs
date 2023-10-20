using GarageConsoleFinalApp.Enums;
using System;

namespace GarageConsoleFinalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            University university = new University("AZMIU", 100, 10000);


            while (true)
            {
                Console.Write("\r\n Menu: ");
                Console.WriteLine("\r\n");
                Console.Write("1. Studentlerin siyahisini gostermek : ");
                Console.WriteLine("\r\n");
                Console.Write("2. Student Yaratmaq : ");
                Console.WriteLine("\r\n");
                Console.Write("3. Studentde deyisiklik etmek : \r\n (studentin groupno deyeri deyisile biler)");
                Console.WriteLine("\r\n");
                Console.Write("4. Studentlerin ortalama qiymeti ve Employeelerin ortalama maasini gostermek :\r\n(1.Spesifik bir qrup uzre, 2. Butun studentleri 3. Butun Employeeleri)");
                Console.WriteLine("\r\n");
                Console.Write("5. Employeelerin siyahisini gostermek : \r\n (sistemdeki butun iscilerin)");
                Console.WriteLine("\r\n");
                Console.Write("6. Universitydeki iscilerin siyahisini gostermrek : \r\n (Departmente gore)");
                Console.WriteLine("\r\n");
                Console.Write("7. Yeni Employee elave etmek");
                Console.WriteLine("\r\n");
                Console.Write("8. Employee uzerinde deyisiklik etmek : \r\n (No daxil edin) :");
                Console.WriteLine("\r\n");
                Console.Write("9. Universityden isci silinmesi : \r\n (No daxil edin)");
                Console.WriteLine("\r\n");
                Console.Write("10. Employee ve ya Studenta gore axtaris etmek : ");
                Console.WriteLine("\r\n");
                Console.WriteLine("11. Sistemden cixis...");


                string choise = Console.ReadLine();
                Console.Clear();

                switch (choise)
                {
                    case "1":
                        university.ShowStudent();
                        break;

                    case "2":
                        AddStudent();
                        break;

                    case "3":
                        StudentUpdate();
                        break;

                    case "4":
                        try
                        {
                            Console.Write("Secim edin : \r\n (1. Group Student or 2. All Student 3. All Employee) \r\n");
                            string secim1 = Console.ReadLine();
                            switch (secim1)
                            {
                                case "1":
                                    Console.Write("Qrup Secin : ");
                                    GroupType groupType = (GroupType)Enum.Parse(typeof(GroupType), Console.ReadLine());
                                    university.CalcGroupStudentsAverage(groupType);
                                    break;
                                case "2":
                                    university.CalcAllStudentsAverage();
                                    break;
                                case "3":
                                    university.CalcSalaryAverage();
                                    break;
                                default:
                                    Console.Write("Secim yanlisdir \r\n");
                                    break;
                            }
                        }
                        catch (Exception)
                        {

                            Console.Write("Xeta bas verdi");
                        }
                        break;

                    case "5":
                        university.ShowEmployee();
                        break;

                    case "6":
                        try
                        {
                            Console.Write("Department secin : ");
                            Department department = (Department)Enum.Parse(typeof(Department), Console.ReadLine());
                            university.ShowDepartmentEmployee(department);
                        }
                        catch (Exception)
                        {

                            Console.Write("Error.. Try again !");
                        }
                        break;

                    case "7":
                        AddEmployee();
                        break;

                    case "8":
                        EmployeeUpdate();
                        break;

                    case "9":
                        Console.Write("EmployeeNo daxil edin : ");
                        string no = Console.ReadLine();
                        university.DeleteEmployee(no);
                        break;

                    case "10":
                        Console.Write("Search : \r\n (1. Employee Type \r\n 2. Group Type \r\n");
                        string secim2 = Console.ReadLine();
                        switch (secim2)
                        {
                            case "1":
                                Console.Write("Enter Employee Type : ");
                                EmployeeType employeeType = (EmployeeType)Enum.Parse(typeof(EmployeeType), Console.ReadLine());
                                university.SearchEmploye(employeeType);
                                break;

                            case "2":
                                Console.Write("Enter Group Type : ");
                                GroupType groupType = (GroupType)Enum.Parse(typeof(GroupType), Console.ReadLine());
                                university.SearchStudent(groupType);
                                break;
                            default:
                                Console.Write("Secim yanlisdir ! \r\n");
                                break;
                        }
                        break;

                    case "11":
                        Console.WriteLine("Sistemden cixilir...");
                        return;

                    default:
                        Console.WriteLine("Yanlis secim ! Yeniden cehd edin \r\n");
                        break;
                }

            }
            
            
            void AddStudent()
            {
                try
                {
                    Console.Write("Fullname daxil edin: ");
                    string fullname = Console.ReadLine();

                    Console.Write("Group Type: ");
                    GroupType groupType = (GroupType)Enum.Parse(typeof(GroupType), Console.ReadLine());

                    Console.Write("Point: ");
                    string pointStr;
                    double point;
                    do
                    {
                        pointStr = Console.ReadLine();
                    } while (!double.TryParse(pointStr, out point));

                    
                    Student student = new Student()
                    {
                        FullName = fullname,
                        GroupType = groupType,
                        GroupNo = groupType.ToString(),
                        Point = point
                    };
                    university.AddStudent(student);
                    Console.WriteLine("Student elave olundu");
                }
                catch (Exception)
                {

                    Console.WriteLine("Error.. Try again !");
                }
            }


            void StudentUpdate()
            {
                try
                {
                    Console.Write("GroupNo daxil edin : ");
                    string eksNo = Console.ReadLine();

                    Console.Write("New point daxil edin : ");
                    string pointStr;
                    double point;
                    do
                    {
                        pointStr = Console.ReadLine();
                    } while (!double.TryParse(pointStr, out point));

                    Student uptStudent = new Student()
                    {

                        Point = point,
                    };
                    university.StudentUpdate(eksNo, point);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error Try.. again !");
                }
            }


            void AddEmployee()
            {
                try
                {
                    Console.Write("Fullname daxil edin : ");
                    string fullname = Console.ReadLine();

                    Console.Write("Department : ");
                    Department department = (Department)Enum.Parse(typeof(Department), Console.ReadLine());

                    Console.Write("Position daxil edin : ");
                    string position = Console.ReadLine();

                    Console.Write("Salary daxil edin : ");
                    string salaryStr;
                    double salary;
                    do
                    {
                        salaryStr = Console.ReadLine();
                    } while (!double.TryParse(salaryStr, out salary));

                    Console.Write("EmployeeType daxil edin : ");
                    EmployeeType employeetype=(EmployeeType)Enum.Parse(typeof(EmployeeType), Console.ReadLine());

                    Employee employee = new Employee
                    {
                        
                        Fullname = fullname,
                        Department = department,
                        empNo = department.ToString(),
                        Position = position,
                        Salary = salary,
                        EmployeeType =employeetype
                    };
                    university.AddEmployee(employee);
                    Console.WriteLine("Employee elave olundu");
                }
                catch (Exception)
                {

                    Console.WriteLine("Error.. Try again !");
                }
            }


            void EmployeeUpdate()
            {
                try
                {
                    Console.Write("EmployeeNo daxil edin : ");
                    string no = Console.ReadLine();

                    Employee employee = new Employee
                    {
                        empNo = no,
                    };
                    university.showEmployeeNo(no);


                    Console.Write("New salary daxil edin : ");
                    string salaryStr;
                    double salary;
                    do
                    {
                        salaryStr = Console.ReadLine();
                    } while (!double.TryParse(salaryStr, out salary));

                    Console.Write("New position daxil edin : ");
                    string position = Console.ReadLine();

                    Employee employee1 = new Employee
                    {
                        Salary= salary,
                        Position=position
                    };
                    university.EmployeeUpdate(no,salary, position);
                }
                catch (Exception)
                {

                    Console.WriteLine("Error.. Try again !"); 
                }
            }

        }

    }
}
