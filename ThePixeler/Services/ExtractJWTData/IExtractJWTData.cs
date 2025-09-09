namespace ThePixeler.Services.ExtractJWTData;

public interface IExtractJWTData
{
    Task<Guid?> GetUserGuid(HttpContext context);
    Task<int> GetUserSubscriptionID(HttpContext context);
    Task<string> GetUserUsername(HttpContext context);

}

// interface SecurityAlgorithmsaaaaa
// {
//     public JWTData getData(string token);
// }
// public class sla : SecurityAlgorithmsaaaaa
// {
//     public JWTData getData(string token)
//     {
//         return new("d","a");
//     }
// }
// public class SecurityAlgorithmsaaaaaaa
// {
//     void slla()
//     {
//         var jwtService = new sla();
//         var userData = jwtService.getData("AAA");

//         System.Console.WriteLine(userData.);
//     }
// }

// record JWTData
// (
//     string name,
//     string role
// );