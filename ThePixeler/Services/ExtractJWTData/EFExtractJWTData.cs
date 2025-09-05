using System.Security.Claims;
using ThePixeler.Models;

namespace ThePixeler.Services.ExtractJWTData;

public class EFExtractJWTData(ThePixelerDbContext ctx) : IExtractJWTData
{
    public async Task<Guid?> GetUserGuid(HttpContext context)
    {
        var claim = context.User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim is null)
            return null;
        var id = Guid.Parse(claim.Value);
        return id;
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