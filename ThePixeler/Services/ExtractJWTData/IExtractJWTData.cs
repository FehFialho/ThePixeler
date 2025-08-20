namespace ThePixeler.Services.ExtractJWTData;

public interface IExtractJWTData
{
    Task<Guid> GetUserGuid();
    Task<int> GetUserSubscriptionID();
    Task<string> GetUserUsername();
    
}