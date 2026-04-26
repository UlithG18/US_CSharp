namespace HealthClinic.Models;

public interface INotifiable
{
    void SendNotification(string message);
}
