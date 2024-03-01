namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var s = new Student(20);
            //Change.ChangeAge(s);
            int number =10;
            Change.ChangeAge(ref number);
        }
    }
    public class Student
    {
        public int Age { get; set; }
        public Student(int age)
        {
            Age = age;
        }
    }
    public static class Change
    {
      public  static void ChangeAge (Student s)
        {
            s.Age += 10;
        }
        public static void ChangeAge( ref int s)
        {
            s += 10;
        }
    }
}