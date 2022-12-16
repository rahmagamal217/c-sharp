Using System

namespace task
{
    public static class Program
    {
        public static void Main(string[] args){

        }
    }
    public class person
    {
        string name;
        int age;
        public person(int age, string name){
            this.name=name;
            this.age=age;
        }
        public abstract void print();    
    }
    public class student : person
    {
        public int year;

        public float gpa;

        public student(string name, int age, int year, float gpa) : base(name, age)
        {
            this.year=year;

            this.gpa=gpa;
        }

        public override void print(){
            Console.WriteLine($"My name is {this.name}, my age is {this.age}, and gpa is {this.gpa}");
        }
    }
    public class Staff : person
    {
        public double salary;
        public int joinYear;

        public Staff(string name, int age, double salary, int joinYear) : base(name, age){
            this.salary=salary;
            this.joinYear=joinYear;
        }
        public override void print(){
            Console.WriteLine($"My name is {this.name}, my age is {this.age}, and my salary is {this.salary}");
        }
    }

}
