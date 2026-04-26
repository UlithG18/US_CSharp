namespace HealthClinic.Models;

public class Utils
{
    public string ValidateName(string message)
    {
        while (true)
        {
            Console.Write(message);
            string name = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty");
                continue;
            }

            bool isValid = true;
            foreach (char l in name)
            {
                if (!char.IsLetter(l) && l != ' ' && l != '-')
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                Console.WriteLine("Name can only contain letters, spaces, or hyphens");
                continue;
            }

            return name;
        }
    }

        public string ValidateNonEmpty(string message)
        {
            while (true)
            {
                Console.Write(message);
                string value = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Value cannot be empty");
                    continue;
                }
                
                return value;
            }
        }

    public int ValidateInteger(string message, int? min = null, int? max = null)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Invalid digit, please enter a valid number");
                continue;
            }

            if ((min != null && value < min) || (max != null && value > max))
            {
                Console.WriteLine($"Please enter a value between {min} and {max}");
                continue;
            }

            return value;
        }
    }
    
    public string ValidateId(string message, int? min = null, int? max = null)
    {
        while (true)
        {
            Console.Write(message); 
            string id = Console.ReadLine()?.Trim() ?? "";
                
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("ID cannot be empty");
                continue;
            }

            if (!int.TryParse(id, out _))
            { 
                Console.WriteLine("Invalid digits, please enter a valid ID"); 
                continue;
            }
            
            int idLength = id.Length;
            
            if ((min != null && idLength < min) || (max != null && idLength > max)) 
            { 
                Console.WriteLine($"Please enter an ID with {min} until {max} digits"); 
                continue;
            }
            
            return id;
        }
    }
}