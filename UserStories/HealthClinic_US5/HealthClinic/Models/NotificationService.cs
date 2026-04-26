namespace HealthClinic.Models;

public class NotificationService
{
    private readonly ErrorLogger _logger = new ErrorLogger();

    public void SendReminder(Dictionary<string, Patient> patientDict, Utils utils)
    {
        Console.WriteLine("\n--- Send Appointment Reminder ---");
        string id = utils.ValidateId("Patient ID (8 to 10): ", 8, 10);

        try
        {
            if (!patientDict.TryGetValue(id, out Patient? patient))
                throw new PatientNotFoundException(id);

            patient.SendNotification("You have an appointment scheduled. Please arrive 10 minutes early");
        }
        catch (PatientNotFoundException ex)
        {
            _logger.Log("SendReminder", ex);
        }
    }

    public void BroadcastMessage(List<Patient> patients, Utils utils)
    {
        Console.WriteLine("\n--- Broadcast Message to All Patients ---");

        if (patients.Count == 0)
        {
            Console.WriteLine("\tNo patients registered");
            return;
        }

        Console.Write("Message to send: ");
        string message = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrEmpty(message))
        {
            Console.WriteLine("\tMessage cannot be empty");
            return;
        }

        foreach (INotifiable notifiable in patients)
            notifiable.SendNotification(message);

        Console.WriteLine($"\n\tMessage sent to {patients.Count} patient(s)");
    }
}
