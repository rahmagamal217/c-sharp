using System;  

namespace task
{
    public class Person
    {
        protected string Name;
        protected int Age;
        public Person(int age, string name){
            if(name == null || name == "" || name.Length >=32)
            {
               throw new Exception("Invalid Name");
            }

            if(age <= 0 || age > 128)
            {
              throw new Exception("Invalid Age");
            }
            Name=name;
            Age=age;
        }
        public virtual void print(){
            Console.WriteLine($"My name is {Name}, my age is {Age}");
        }    
    }
    public class DataBase
    {
        int current_index;
        public Person[] people = new Person[50];

        public void AddStudent (Student student){
            people[current_index++]=student;
        }
        public void AddStaff (Staff staff){
            people[current_index++]=staff;
        }
        public void AddPerson (Person person){
            people[current_index++]=person;
        }
        public void PrintAll(){
            for (int i = 0; i < current_index; i++)
            {
                people[i].print();
            }
        }
    }

    public class Student : Person
    {
        public int Year;

        public float Gpa;

        public Student(string name, int age, int year, float gpa) : base(age, name)
        {
            if(!(year >= 1 && year <= 5))
            {
               throw new Exception("Invalid Year");
            }

            if(!(gpa >= 0 && gpa <= 4))
            {
               throw new Exception("Invalid Gpa");
            }

            Year=year;

            Gpa=gpa;
        }

        public override void print(){
            Console.WriteLine($"My name is {Name}, my age is {Age}, and gpa is {Gpa}");
        }
    }
    public class Staff : Person
    {
        public double Salary;
        public int JoinYear;

        public Staff(string name, int age, double salary, int joinYear) : base(age, name){
            if(salary <= 0 || salary > 120_000)
            {
               throw new Exception("Invalid Salary");
            }
            DateTime date=DateTime.Today;
            int birthYear=date.Year-Age;
            if((joinYear-birthYear) < 21)
            {
              throw new Exception("Invalid JoinYear");
            }

            Salary=salary;
            JoinYear=joinYear;
        }
        public override void print(){
            Console.WriteLine($"My name is {Name}, my age is {Age}, and my salary is {Salary}");
        }
    }

    public static class Program
    {
        public static void Main(string[] args){
            
            DataBase data=new DataBase();
            
            Console.WriteLine("1.Student 2.Staff 3.Person 4.Print All");
            var option=Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                 Console.WriteLine("Enter your name");
                 var name=Console.ReadLine();
                 Console.WriteLine("Enter your age");
                 var age=Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter your year");
                 var year=Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter your gpa");
                 var gpa=Convert.ToSingle(Console.ReadLine());
                 try
                 {
                     Student student=new Student(name, age, year, gpa);
                     data.AddStudent(student);
                 }
                 catch (Exception e)
                 {
                    
                     Console.WriteLine(e.Message);
                 }
                 break;

                case 2:
                 Console.WriteLine("Enter your name");
                 var name2=Console.ReadLine();
                 Console.WriteLine("Enter your age");
                 var age2=Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter your salary");
                 var salary=Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter your joinYear");
                 var joinYear=Convert.ToInt32(Console.ReadLine());
                 try
                 {
                     Staff staff=new Staff(name2, age2, salary, joinYear);
                     data.AddStaff(staff);
                 }
                 catch (Exception e)
                 {
                    
                     Console.WriteLine(e.Message);
                 }
                 break;
                case 3:
                 Console.WriteLine("Enter your name");
                 var name3=Console.ReadLine();
                 Console.WriteLine("Enter your age");
                 var age3=Convert.ToInt32(Console.ReadLine());
                 try
                 {
                     Person person=new Person(age3, name3);
                     data.AddPerson(person);
                 }
                 catch (Exception e)
                 {
                    
                     Console.WriteLine(e.Message);
                 }
                 break;
                case 4:
                 data.PrintAll();
                 break;
                
                default:
                return;
            }
        }
    }

}
