namespace HealthClinic.Models;

public class PetService
{
    Utils utils = new Utils();
    ErrorLogger logger = new ErrorLogger();

    public void RegisterPet(Dictionary<string, Patient> patientDict)
    {
        Console.WriteLine("\n--- Register Pet for Patient ---");
        string id = utils.ValidateId("Patient ID (8 to 10): ", 8, 10);

        try
        {
            if (!patientDict.TryGetValue(id, out Patient? patient))
                throw new PatientNotFoundException(id);

            string name = utils.ValidateName("Pet name: ");
            string species = utils.ValidateNonEmpty("Species (Dog, Cat, Bird...): ");
            string breed = utils.ValidateNonEmpty("Breed (or - if unknown): ");
            int age = utils.ValidateInteger("Pet age: ", 0, 50);

            Pet pet = new Pet(name, species, breed, age, patient.Name);
            patient.Pets.Add(pet);

            pet.Register();
            pet.PrintInfo();
        }
        catch (PatientNotFoundException ex)
        {
            logger.Log("RegisterPet", ex);
        }
    }
}
