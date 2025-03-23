namespace Tutorial3;

public interface IHazardNotifier<T>
{
    void Send(string? message, SerialNumber<T> serial);
}