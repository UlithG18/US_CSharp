using HealthClinic.Models;

List<Patient> patients = new List<Patient>();
Dictionary<string, Patient> patientDict = new Dictionary<string, Patient>();

PatientService patientService = new PatientService();
PetService petService = new PetService();
LinqService linqService = new LinqService();
Utils utils = new Utils();

while (true)
{
    Console.WriteLine("Welcome to Health Clinic");
    Console.Write(
        "\n\t--- Patients ---\n\t1. Register Patient\n\t2. List Patients\n\t3. Search Patient\n\t4. Update Patient\n\t5. Remove Patient\n\n\t--- Pets ---\n\t6. Register Pet for Patient\n\n\t--- LINQ Queries ---\n\t7. Filter patients by age\n\t8. Filter patients by pet species\n\t9. List patient names (A-Z, uppercase)\n\t10. Group pets by species\n\t11. Youngest and oldest patient\n\t12. Check pets without breed\n\n\t0. Exit\n\n");

    int option = utils.ValidateInteger("Enter an option: ", 0, 12);

    switch (option)
    {
        case 1:
            patientService.RegisterPatient(patients, patientDict);
            break;
        case 2:
            patientService.ListPatients(patients);
            break;
        case 3:
            patientService.SearchPatient(patientDict);
            break;
        case 4:
            patientService.UpdatePatient(patientDict);
            break;
        case 5:
            patientService.DeletePatient(patients, patientDict);
            break;
        case 6:
            petService.RegisterPet(patientDict);
            break;
        case 7:
            linqService.FilterByAge(patients);
            break;
        case 8:
            linqService.FilterBySpecies(patients);
            break;
        case 9:
            linqService.ListNamesUppercase(patients);
            break;
        case 10:
            linqService.GroupPetsBySpecies(patients);
            break;
        case 11:
            linqService.ShowAgeExtremes(patients);
            break;
        case 12:
            linqService.CheckPetsWithoutBreed(patients);
            break;
        case 0:
            Console.WriteLine("\nBye, have a nice day");
            return;
        default:
            Console.WriteLine("Please enter a valid option");
            break;
    }
}
