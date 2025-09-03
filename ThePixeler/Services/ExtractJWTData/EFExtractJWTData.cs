using ThePixeler.Models;

namespace ThePixeler.Services.ExtractJWTData;

public class EFExtractJWTData(ThePixelerDbContext ctx) : IExtractJWTData
{
    public Task<Guid> GetUserGuid(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetUserSubscriptionID(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserUsername(HttpContext context)
    {
        throw new NotImplementedException();
    }
}