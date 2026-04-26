namespace HealthClinic.Models;

public class PetService
{
    Utils utils = new Utils();

    public void RegisterPet(Dictionary<string, Patient> patientDict)
    {
        Console.WriteLine("\n--- Register Pet for Patient ---");
        string id = utils.ValidateId("Patient ID (8 to 10): ", 8, 10);

        if (!patientDict.TryGetValue(id, out Patient patient))
        {
            Console.WriteLine($"No patient found with ID: {id}");
            return;
        }

        string name = utils.ValidateName("Pet name: ");
        string species = utils.ValidateNonEmpty("Species (Dog, Cat, Bird...): ");
        string breed = utils.ValidateNonEmpty("Breed: ");
        int age = utils.ValidateInteger("Pet age: ", 0, 50);

        Pet pet = new Pet(name, species, breed, age);
        patient.Pets.Add(pet);

        Console.WriteLine("\nPet registered successfully");
        pet.PrintInfo();
    }
}
