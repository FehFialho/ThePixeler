namespace ThePixeler.Services.IPasswordServices;

public interface IPasswordService
{
    string Hash(string password);
    bool Compare(string password, string hash);
}