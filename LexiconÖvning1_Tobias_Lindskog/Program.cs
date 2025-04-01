namespace LexiconÖvning1_Tobias_Lindskog
{
    internal class Program
    {
        class Employee
        {
            private static List<Employee> register = new List<Employee>();   

            public string name { get; set; }
            public float salary {  get; set; }

            public Employee(string _name, float _salary)
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
        
        static void Menu(string headerMessage = "")
        {
            if (headerMessage != "") Console.WriteLine(headerMessage);
            Console.WriteLine("Skriv \"1\" för att skriva ut registret");
            Console.WriteLine("Skriv \"2\" för att lägga till en nyanställd");
            Console.WriteLine("Skriv \"3\" för att avsluta");
            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                PrintRegister();
            }
            else if (input == "2")
            {
                Console.Clear();
                AddNewEmployee();
            }
            else
            {
                Console.Clear();
                Menu("Fel inmatning");
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
                    Console.WriteLine("{0, -20} {1, 10:C}", person.name, person.salary);
                }  
            }
            
            Console.WriteLine();
            Menu();
        }

        static void AddNewEmployee()
        {
            string name;
            float salary;
            Console.Write("Fullständigt namn på den nyanställda: ");
            do
            {
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            Console.Write("Lön i kr: ");
            do
            {
                salary = ParseStringToFloat(Console.ReadLine());
            } while (salary==-1);

            Employee newHire = new Employee(name, salary);
            
            Console.Clear();
            Menu($"{newHire.name} lades till i registret");
        }

        static float ParseStringToFloat(string message)
        {
            string stringOfDigits = "";
            bool success = false;
            if (message == "")
            {
                Console.Write("Du måste skriva ett nummer: ");
                return -1;
            }
            foreach (char character in message.ToCharArray())
            {
                
                if ((character == '.' || character == ',') && !stringOfDigits.Contains(',')) stringOfDigits += ',';
                else if (char.IsDigit(character))
                {
                    stringOfDigits += character;
                    success = true;
                }
                
            }
            if (success) return float.Parse(stringOfDigits);
            else
            {
                Console.Write("Du måste skriva ett nummer: ");
                return -1;    
            }
        }
    }
}
