namespace HealthClinic.Models;

public class Pet : Animal, IRegistrable
{
    public string Breed { get; set; }
    public string Owner { get; set; }

    public Pet(string name, string species, string breed, int age, string owner)
        : base(name, age, species)
    {
        Breed = breed;
        Owner = owner;
    }

    public override string MakeSound()
    {
        return Species.ToLower() switch
        {
            "dog"  => "Woof!",
            "cat"  => "Meow!",
            "bird" => "Tweet!",
            _      => "..."
        };
    }

    public void Register()
    {
        Console.WriteLine($"\tPet registered -> {Name} ({Species}) owned by {Owner}");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"\n\t\t--- Pet Information ---\n\n\tName: {Name}\n\tSpecies: {Species}\n\tBreed: {Breed}\n\tAge: {Age}\n\tSound: {MakeSound()}\n\tOwner: {Owner}\n");
    }
}
