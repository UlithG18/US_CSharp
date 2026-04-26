namespace HealthClinic.Models;

public class PatientService
{
    Utils utils = new Utils();
    ErrorLogger logger = new ErrorLogger();

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

        try
        {
            Patient newPatient = new Patient(id, name, age, symptom);
            patients.Add(newPatient);
            patientDict[id] = newPatient;

            newPatient.Register();
            newPatient.PrintInfo();
        }
        catch (Exception ex)
        {
            logger.Log("RegisterPatient", ex);
        }
        finally
        {
            Console.WriteLine("\tRegister operation finished");
        }
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
        Console.WriteLine("\n  --- Search Patient ---");
        string id = utils.ValidateId("Enter the patient ID (8 to 10): ", 8, 10);

        try
        {
            if (!patientDict.TryGetValue(id, out Patient? found))
                throw new PatientNotFoundException(id);

            found.PrintInfo();
        }
        catch (PatientNotFoundException ex)
        {
            logger.Log("SearchPatient", ex);
        }
    }

    public void UpdatePatient(Dictionary<string, Patient> patientDict)
    {
        Console.WriteLine("\n  --- Update Patient ---");
        string id = utils.ValidateId("Enter the patient ID (8 to 10): ", 8, 10);

        try
        {
            if (!patientDict.TryGetValue(id, out Patient? found))
                throw new PatientNotFoundException(id);

            string name = utils.ValidateName("New patient name: ");
            int age = utils.ValidateInteger("New patient age: ", 0, 120);
            string symptom = utils.ValidateNonEmpty("New symptoms: ");

            found.Name = name;
            found.Age = age;
            found.Symptom = symptom;

            Console.WriteLine("\nPatient updated successfully");
            found.PrintInfo();
        }
        catch (PatientNotFoundException ex)
        {
            logger.Log("UpdatePatient", ex);
        }
    }

    public void DeletePatient(List<Patient> patients, Dictionary<string, Patient> patientDict)
    {
        Console.WriteLine("\n  --- Delete Patient ---");
        string id = utils.ValidateId("Enter the patient ID (8 to 10): ", 8, 10);

        try
        {
            if (!patientDict.TryGetValue(id, out Patient? found))
                throw new PatientNotFoundException(id);

            patients.Remove(found);
            patientDict.Remove(id);
            Console.WriteLine($"\nPatient {found.Name} removed successfully");
        }
        catch (PatientNotFoundException ex)
        {
            logger.Log("DeletePatient", ex);
        }
    }
}
