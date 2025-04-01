namespace LexiconÖvning1_Tobias_Lindskog
{
    internal class Program
    {
        class Employee
        {
            private static List<Employee> register = new List<Employee>();   

            public string name { get; set; }
            public string salary {  get; set; }

            public Employee(string _name, string _salary)
            {
                name = _name;
                salary = _salary;
                register.Add(this);
            }

            public static List<Employee> GetRegister()
            {
                return register;
            }
        }
       
        static void Main(string[] args)
        {
            Menu();
        }
        
        static void Menu()
        {
            Console.WriteLine("Skriv \"1\" för att skriva ut registret");
            Console.WriteLine("Skriv \"2\" för att lägga till en nyanställd");
            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine();
                PrintRegister();
            }
            else if (input == "2")
            {
                Console.WriteLine();
                AddNewEmployee();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Fel inmatning");
                Menu();
            }
        }
        
        static void PrintRegister()
        {
            if (Employee.GetRegister().Count == 0) Console.WriteLine("Registret är tomt");
            else
            {
                Console.WriteLine("{0,-20} {1,10}", "Namn", "Lön");
                foreach (var person in Employee.GetRegister())
                {
                    Console.WriteLine("{0, -20} {1, 10}", person.name, person.salary);
                }  
            }

            
            Console.WriteLine();
            Menu();
        }

        static void AddNewEmployee()
        {
            Console.WriteLine("Fullständigt namn på den nyanställda: ");
            string name = Console.ReadLine();
            Console.WriteLine("Lön på den nyanställda: ");
            string salary = Console.ReadLine();
            Employee newHire = new Employee(name, salary);
            Console.WriteLine("{0} lades till i registret", newHire.name);

            Console.WriteLine();
            Menu();
        }
    }
}
