namespace HealthClinic.Models;

public class ErrorLogger
{
    private readonly string _logPath = "clinic_errors.log";

    public void Log(string context, Exception ex)
    {
        string entry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{context}] {ex.GetType().Name}: {ex.Message}";

        Console.WriteLine($"\n\t[ERROR] {ex.Message}");

        try
        {
            File.AppendAllText(_logPath, entry + Environment.NewLine);
        }
        catch
        {
            
        }
    }
}
