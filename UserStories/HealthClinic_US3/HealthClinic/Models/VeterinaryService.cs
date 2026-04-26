namespace HealthClinic.Models;

public abstract class VeterinaryService
{
    public string ServiceName { get; set; }

    public VeterinaryService(string serviceName)
    {
        ServiceName = serviceName;
    }

    public abstract void Attend(Patient patient);
}

public class GeneralConsultation : VeterinaryService
{
    public GeneralConsultation() : base("General Consultation") { }

    public override void Attend(Patient patient)
    {
        Console.WriteLine($"\n\t[General Consultation] Attending patient: {patient.Name}");
        Console.WriteLine($"\tReviewing symptom: {patient.Symptom}");
        Console.WriteLine("\tConsultation completed");
    }
}

public class Vaccination : VeterinaryService
{
    public Vaccination() : base("Vaccination") { }

    public override void Attend(Patient patient)
    {
        Console.WriteLine($"\n\t[Vaccination] Attending patient: {patient.Name}");
        if (patient.Pets.Count == 0)
        {
            Console.WriteLine("\tNo pets registered for this patient.");
            return;
        }
        foreach (Pet pet in patient.Pets)
            Console.WriteLine($"\tVaccine applied to: {pet.Name} ({pet.Species})");
        Console.WriteLine("\tVaccination completed");
    }
}
