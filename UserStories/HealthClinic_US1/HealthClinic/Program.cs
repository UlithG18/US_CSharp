using HealthClinic.Models;



List<Patient> patients = new List<Patient>();
PatientService service = new PatientService();
Utils utils = new Utils();



while (true)
{
    Console.WriteLine("Welcome to Health Clinic");
    Console.Write("\n\t1. Register Patient  \n\t2. List Patients \n\t3. Search Patient \n\t4. Update Patient \n\t5. Remove Patient \n\t6. Exit \n\n\tPlease enter an option to continue (1 - 6): ");

    int option = utils.ValidateInteger("\nEnter an option (1 - 6): ", 1, 6);

    switch (option)
    {
        case 1:
            service.RegisterPatient(patients);
            break;

        case 2:
            service.ListPatients(patients);
            break;

        case 3:
            service.SearchPatient(patients);
            break;
        
        case 4:
            service.UpdatePatient(patients);
            break;
        
        case 5:
            service.DeletePatient(patients);
            break;
        
        case 6:
            Console.WriteLine("\nBye, have a nice day");
            return;

        default:
            Console.WriteLine("Please enter a valid option");
            break;
    }
}
