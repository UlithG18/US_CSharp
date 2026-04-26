namespace HealthClinic.Models;

public class AsyncClinicService
{
    public async Task RegisterPatientAsync(Patient patient)
    {
        Console.WriteLine($"\n\t[Async] Starting registration for {patient.Name}...");
        await Task.Delay(1000);
        patient.Register();
        Console.WriteLine($"\t[Async] Registration for {patient.Name} completed");
    }

    public async Task LoadClinicalHistoryAsync(Patient patient)
    {
        Console.WriteLine($"\t[Task] Loading clinical history for {patient.Name}...");
        await Task.Delay(1500);
        Console.WriteLine($"\t[Task] Clinical history loaded for {patient.Name}");
    }

    public async Task ScheduleAppointmentAsync(Patient patient)
    {
        Console.WriteLine($"\t[Task] Scheduling appointment for {patient.Name}...");
        await Task.Delay(800);
        Console.WriteLine($"\t[Task] Appointment scheduled for {patient.Name}");
    }

    public async Task SendNotificationAsync(Patient patient)
    {
        Console.WriteLine($"\t[Task] Sending notification to {patient.Name}...");
        await Task.Delay(500);
        patient.SendNotification("Your appointment has been confirmed");
    }

    public async Task ProcessPatientAsync(Patient patient)
    {
        Console.WriteLine($"\n\t--- Processing patient {patient.Name} (parallel tasks) ---");

        await Task.WhenAll(
            LoadClinicalHistoryAsync(patient),
            ScheduleAppointmentAsync(patient),
            SendNotificationAsync(patient)
        );

        Console.WriteLine($"\t--- All tasks completed for {patient.Name} ---");
    }

    public async Task RegisterPetsAsync(Patient patient)
    {
        if (patient.Pets.Count == 0)
        {
            Console.WriteLine("\tNo pets registered for this patient");
            return;
        }

        Console.WriteLine($"\n\t--- Registering {patient.Pets.Count} pet(s) concurrently ---");

        List<Task> petTasks = new List<Task>();
        foreach (Pet pet in patient.Pets)
        {
            petTasks.Add(Task.Run(async () =>
            {
                await Task.Delay(700);
                Console.WriteLine($"\t[Pet] {pet.Name} ({pet.Species}) registered asynchronously");
            }));
        }

        await Task.WhenAll(petTasks);
        Console.WriteLine("\t--- All pets registered ---");
    }

    public async Task ShowFastestServiceAsync(Patient patient)
    {
        Console.WriteLine($"\n\t--- WhenAny: first service to respond for {patient.Name} ---");

        Task t1 = Task.Run(async () => { await Task.Delay(1200); Console.WriteLine("\t[Service A] General check done."); });
        Task t2 = Task.Run(async () => { await Task.Delay(600);  Console.WriteLine("\t[Service B] Quick scan done."); });
        Task t3 = Task.Run(async () => { await Task.Delay(900);  Console.WriteLine("\t[Service C] Lab results ready."); });

        Task fastest = await Task.WhenAny(t1, t2, t3);
        Console.WriteLine("\t[WhenAny] First service responded, waiting for the rest...");

        await Task.WhenAll(t1, t2, t3);
        Console.WriteLine("\t[WhenAll] All services completed");
    }
}
