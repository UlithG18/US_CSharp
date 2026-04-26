namespace HealthClinic.Models;

public class LinqService
{

    public void FilterByAge(List<Patient> patients)
    {
        Console.Write("Minimum age: ");
        int minAge = int.Parse(Console.ReadLine() ?? "0");

        var result = patients.Where(p => p.Age >= minAge).ToList();

        Console.WriteLine($"\n--- Patients aged {minAge} or older ---");
        if (result.Count == 0) { Console.WriteLine("No results"); return; }
        foreach (var p in result)
            Console.WriteLine($"\t{p.Name} - Age: {p.Age}");
    }

    public void FilterBySpecies(List<Patient> patients)
    {
        Console.Write("Species to search: ");
        string species = Console.ReadLine()?.Trim() ?? "";

        var result = patients
            .Where(p => p.Pets.Any(pet => pet.Species.Equals(species, StringComparison.OrdinalIgnoreCase)))
            .OrderBy(p => p.Age)
            .Select(p => new { p.Name, p.Age })
            .ToList();

        Console.WriteLine($"\n--- Patients with a {species} (ordered by age) ---");
        if (result.Count == 0) { Console.WriteLine("No results"); return; }
        foreach (var p in result)
            Console.WriteLine($"\t{p.Name} - Age: {p.Age}");
    }

    public void ListNamesUppercase(List<Patient> patients)
    {
        var names = patients
            .OrderBy(p => p.Name)
            .Select(p => p.Name.ToUpper())
            .ToList();

        Console.WriteLine("\n--- Patient names (A-Z, uppercase) ---");
        if (names.Count == 0) { Console.WriteLine("No patients"); return; }
        foreach (var name in names)
            Console.WriteLine($"\t{name}");
    }

    public void GroupPetsBySpecies(List<Patient> patients)
    {
        var groups = patients
            .SelectMany(p => p.Pets)
            .GroupBy(pet => pet.Species)
            .Select(g => new { Species = g.Key, Count = g.Count() });

        Console.WriteLine("\n--- Pets grouped by species ---");
        bool any = false;
        foreach (var g in groups)
        {
            Console.WriteLine($"\t{g.Species}: {g.Count}");
            any = true;
        }
        if (!any) Console.WriteLine("No pets registered");
    }

    public void ShowAgeExtremes(List<Patient> patients)
    {
        if (patients.Count == 0) { Console.WriteLine("No patients registered"); return; }

        Patient youngest = patients.OrderBy(p => p.Age).First();
        Patient oldest = patients.OrderByDescending(p => p.Age).First();

        Console.WriteLine("\n--- Age extremes ---");
        Console.WriteLine($"\tYoungest: {youngest.Name} ({youngest.Age})");
        Console.WriteLine($"\tOldest:   {oldest.Name} ({oldest.Age})");
    }

    public void CheckPetsWithoutBreed(List<Patient> patients)
    {
        bool exists = patients
            .SelectMany(p => p.Pets)
            .Any(pet => string.IsNullOrWhiteSpace(pet.Breed) || pet.Breed == "-");

        Console.WriteLine(exists
            ? "\n\tThere is at least one pet with no breed defined"
            : "\n\tAll pets have a breed defined");
    }
}
