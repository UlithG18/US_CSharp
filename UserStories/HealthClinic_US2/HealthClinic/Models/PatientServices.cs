namespace HealthClinic.Models;

public class PatientService
{
    Utils utils = new Utils();

    public void RegisterPatient(List<Patient> patients, Dictionary<string, Patient> patientDict)
    {
        Console.WriteLine("\n--- Register New Patient ---");

        string id = utils.ValidateId("Patient ID (8 to 10): ", 8, 10);

        if (patientDict.ContainsKey(id))
        {
            Console.WriteLine("A patient with that ID already exists");
            return;
        }

        string name = utils.ValidateName("Patient name: ");
        int age = utils.ValidateInteger("Patient age: ", 0, 120);
        string symptom = utils.ValidateNonEmpty("Symptoms: ");

        Patient newPatient = new Patient(id, name, age, symptom);
        patients.Add(newPatient);
        patientDict[id] = newPatient;

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
            patient.PrintInfo();

        Console.WriteLine($"\nTotal patients: {patients.Count}");
    }

    public void SearchPatient(Dictionary<string, Patient> patientDict)
    {
        Console.Write("\n  --- Search Patient ---  ");
        string id = utils.ValidateId("Enter the patient ID (8 to 10): ", 8, 10);

        if (!patientDict.TryGetValue(id, out Patient found))
        {
            Console.WriteLine($"No patient found with ID: {id}");
            return;
        }

        found.PrintInfo();
    }

    public void UpdatePatient(Dictionary<string, Patient> patientDict)
    {
        Console.Write("\n  --- Update Patient ---  ");
        string id = utils.ValidateId("Enter the patient ID (8 to 10): ", 8, 10);

        if (!patientDict.TryGetValue(id, out Patient found))
        {
            Console.WriteLine($"No patient found with ID: {id}");
            return;
        }

        string name = utils.ValidateName("New patient name: ");
        int age = utils.ValidateInteger("New patient age: ", 0, 120);
        string symptom = utils.ValidateNonEmpty("New symptoms: ");

        found.Name = name;
        found.Age = age;
        found.Symptom = symptom;

        Console.WriteLine("\nPatient updated successfully");
        found.PrintInfo();
    }

    public void DeletePatient(List<Patient> patients, Dictionary<string, Patient> patientDict)
    {
        Console.Write("\n  --- Delete Patient ---  ");
        string id = utils.ValidateId("Enter the patient ID (8 to 10): ", 8, 10);

        if (!patientDict.TryGetValue(id, out Patient found))
        {
            Console.WriteLine($"No patient found with ID: {id}");
            return;
        }

        patients.Remove(found);
        patientDict.Remove(id);
        Console.WriteLine($"\nPatient {found.Name} removed successfully");
    }
}
