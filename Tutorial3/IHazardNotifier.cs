namespace Tutorial3;

public interface IHazardNotifier
{
    void Send(string? message, SerialNumber serial);
}