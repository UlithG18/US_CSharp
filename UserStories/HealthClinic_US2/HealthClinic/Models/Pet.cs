namespace HealthClinic.Models;

public class Pet
{
    public string Name { get; set; }
    public string Species { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }

    public Pet(string name, string species, string breed, int age)
    {
        Name = name;
        Species = species;
        Breed = breed;
        Age = age;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"\n\t\t--- Pet Information ---\n\n\tName: {Name}\n\tSpecies: {Species}\n\tBreed: {Breed}\n\tAge: {Age}\n");
    }
}
