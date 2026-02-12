namespace SealedClass
{
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }

    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }

    }
    sealed class Executive : Employee
    {

        public string Title { get; set; }
        public double Salary { get; set; }



        //default
        public Executive() : base()
        {
            Title = string.Empty;
            Salary = 0;
        }
        //param
        public Executive(int id, string firstName, string lastName, string title, double salary)
            : base(id, firstName, lastName)
        {
            Title = title;
            Salary = salary;
        }
        //method override
        public override double Pay()
        {
            double salary;
            if (Salary > 0) { salary = Salary; }
            else
            {
                Console.WriteLine($"What is {this.Fullname()}'s monthly pay?");
                salary = double.Parse(Console.ReadLine());
            }
            salary = salary * 12;
            return salary;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Employee John = new Employee(12, "John", "Doe");
            Console.WriteLine($"{John.Fullname()}\n" +
                $"Weekly Pay: {John.Pay()}\n");
            Executive Jane = new Executive(10, "Jane", "Doe", "boss", 5000.50);
            Console.WriteLine($"{Jane.Fullname()}\n" +
                $"Annual Salary: {Jane.Pay()}");
        }
    }
}
