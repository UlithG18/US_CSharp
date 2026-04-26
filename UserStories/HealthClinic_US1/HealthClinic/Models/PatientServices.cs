namespace HealthClinic.Models;

public class PatientService
{
    Utils utils = new Utils();
    

    public void RegisterPatient(List<Patient> patients)
    {
        Console.WriteLine("\n--- Register New Patient ---");

        string id = utils.ValidateId("Patient ID (8 to 10): ", 8, 10);

        // Check for duplicate ID
        if (patients.Exists(patient => patient.Id == id))
        {
            Console.WriteLine("A patient with that ID already exists");
            return;
        }

        string name = utils.ValidateName("Patient name: ");
        int age = utils.ValidateInteger("Patient age: ", 0, 120);
        string symptom = utils.ValidateNonEmpty("Symptoms: ");

        Patient newPatient = new Patient(id, name, age, symptom);
        patients.Add(newPatient);

        Console.WriteLine("\nPatient registered");
        newPatient.PrintInfo();
    }

    public void ListPatients(List<Patient> patients)
    {
        Console.WriteLine("\n\t\t--- Patient List ---");

        if (patients.Count == 0)
        {
            Console.WriteLine("No patients registered yet");
            return;
        }

        foreach (Patient patient in patients)
        {
            patient.PrintInfo();
        }

        Console.WriteLine($"\nTotal patients: {patients.Count}");
    }

    public void SearchPatient(List<Patient> patients)
    {
        Console.Write("\n  --- Searching User ---  ");
        string id = utils.ValidateId("Enter the patient ID to look for the patient (8 to 10): ", 8, 10);
            
        Patient found = patients.Find(patient => patient.Id == id);

        if (found == null)
        {
            Console.WriteLine($"No patients found with Id: {id}");
            return;
        }

        found.PrintInfo();
    }
    
    public void UpdatePatient(List<Patient> patients)
    {
        Console.Write("\n  --- User Update ---  ");
        string id = utils.ValidateId("Enter the patient ID to look for the patient (8 to 10): ", 8, 10);
            
        Patient found = patients.Find(patient => patient.Id == id);

        if (found == null)
        {
            Console.WriteLine($"No patients found with Id: {id}");
            return;
        }

        string name = utils.ValidateName("New Patient name: ");
        int age = utils.ValidateInteger("New Patient age: ", 0, 120);
        string symptom = utils.ValidateNonEmpty("New Symptoms: ");

        found.Name = name;
        found.Age = age;
        found.Symptom = symptom;

        Console.WriteLine("\nPatient updated successfully");
        found.PrintInfo();
    }

    public void DeletePatient(List<Patient> patients)
    {
        Console.Write("\n  --- User Deletion ---  ");
        string id = utils.ValidateId("Enter the patient ID to look for the patient (8 to 10): ", 8, 10);
            
        Patient found = patients.Find(patient => patient.Id == id);

        if (found == null)
        {
            Console.WriteLine($"No patients found with Id: {id}");
            return;
        }
        
        patients.Remove(found);
        Console.WriteLine($"\nPatient {found.Name} removed successfully");
    }
}   