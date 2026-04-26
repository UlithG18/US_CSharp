using HealthClinic.Models;

List<Patient> patients = new List<Patient>();
Dictionary<string, Patient> patientDict = new Dictionary<string, Patient>();

PatientService patientService = new PatientService();
PetService petService = new PetService();
LinqService linqService = new LinqService();
NotificationService notificationService = new NotificationService();
Utils utils = new Utils();

List<VeterinaryService> vetServices = new List<VeterinaryService>
{
    new GeneralConsultation(),
    new Vaccination()
};

while (true)
{
    Console.WriteLine("Welcome to Health Clinic");
    Console.Write(
        "\n\t--- Patients ---\n\t1.  Register Patient\n\t2.  List Patients\n\t3.  Search Patient\n\t4.  Update Patient\n\t5.  Remove Patient"\n\n\t--- Pets ---\n\t6.  Register Pet for Patient"\n\n\t--- Veterinary Services ---\n\t7.  General Consultation\n\t8.  Vaccination"\n\n\t--- Notifications ---\n\t9.  Send Appointment Reminder\n\t10. Broadcast Message to All Patients"\n\n\t--- LINQ Queries ---\n\t11. Filter patients by age\n\t12. Filter patients by pet species\n\t13. List patient names (A-Z, uppercase)\n\t14. Group pets by species\n\t15. Youngest and oldest patient\n\t16. Check pets without breed"\n\n\t0.  Exit\n\n");

    int option = utils.ValidateInteger("Enter an option: ", 0, 16);

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
        case 8:
            string svcId = utils.ValidateId("Patient ID (8 to 10): ", 8, 10);
            
            if (patientDict.TryGetValue(svcId, out Patient? svcPatient))
                vetServices[option - 7].Attend(svcPatient);
            else
                Console.WriteLine($"\tNo patient found with ID: {svcId}");

            break;
        case 9:
            notificationService.SendReminder(patientDict, utils);
            break;
        case 10:
            notificationService.BroadcastMessage(patients, utils);
            break;
        case 11:
            linqService.FilterByAge(patients);
            break;
        case 12:
            linqService.FilterBySpecies(patients);
            break;
        case 13:
            linqService.ListNamesUppercase(patients);
            break;
        case 14:
            linqService.GroupPetsBySpecies(patients);
            break;
        case 15:
            linqService.ShowAgeExtremes(patients);
            break;
        case 16:
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
