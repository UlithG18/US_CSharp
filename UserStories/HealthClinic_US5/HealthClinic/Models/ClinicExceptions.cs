namespace HealthClinic.Models;

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string id)
        : base($"No patient found with ID: {id}") { }
}

public class PetNotFoundException : Exception
{
    public PetNotFoundException(string petName)
        : base($"No pet found with name: {petName}") { }
}
