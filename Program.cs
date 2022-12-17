using System;  
using System.Collections;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;

namespace task
{
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
                 var joinYear=Convert.ToSingle(Console.ReadLine());
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
                     Person person=new Person(name3, age3);
                     data.AddPerson(person);
                 }
                 catch (Exception e)
                 {
                    
                     Console.WriteLine(e.Message);
                 }
                 break;
                case 4:
                 data.Print();
                 break;
                
                default:
                return;
            }
        }
    }
    public class Person
    {
        string name;
        int age;
        public Person(int age, string name){
            if(name == null || name == "" || name.Length >=32)
            {
               throw new Exception("Invalid Name");
            }

            if(age <= 0 || age > 128)
            {
              throw new Exception("Invalid Age");
            }
            this.name=name;
            this.age=age;
        }
        public abstract void print();    
    }
    public class DataBase
    {
        int current_index;
        public person[] people = new person[50];

        public void AddStudent (student student){
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
        public int year;

        public float gpa;

        public Student(string name, int age, int year, float gpa) : base(name, age)
        {
            if(year! >= 1 && year! <= 5)
            {
               throw new Exception("Invalid Year");
            }

            if(gpa! >= 0 && gpa! <= 4)
            {
               throw new Exception("Invalid Gpa");
            }

            this.year=year;

            this.gpa=gpa;
        }

        public override void print(){
            Console.WriteLine($"My name is {this.name}, my age is {this.age}, and gpa is {this.gpa}");
        }
    }
    public class Staff : Person
    {
        public double salary;
        public int joinYear;
        var date=DateTime.Today;
        var birthYear=date.Year-this.age

        public Staff(string name, int age, double salary, int joinYear) : base(name, age){
            if(salary <= 0 || salary > 120_000)
            {
               throw new Exception("Invalid Salary");
            }

            if((joinYear-birthYear) < 21)
            {
              throw new Exception("Invalid JoinYear");
            }

            this.salary=salary;
            this.joinYear=joinYear;
        }
        public override void print(){
            Console.WriteLine($"My name is {this.name}, my age is {this.age}, and my salary is {this.salary}");
        }
    }

}
