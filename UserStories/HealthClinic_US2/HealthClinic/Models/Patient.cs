namespace HealthClinic.Models;

public class Patient
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Symptom { get; set; }

    public List<Pet> Pets { get; set; } = new List<Pet>();

    public Patient(string id, string name, int age, string symptom)
    {
        Id = id;
        Name = name;
        Age = age;
        Symptom = symptom;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"\n\t\t--- Patient Information ---\n\n\tID: {Id}\n\tName: {Name}\n\tAge: {Age}\n\tSymptom: {Symptom}\n\tPets: {Pets.Count}\n");
        foreach (Pet pet in Pets)
            pet.PrintInfo();
    }
}