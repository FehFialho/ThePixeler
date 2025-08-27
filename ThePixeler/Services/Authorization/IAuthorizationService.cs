using ThePixeler.Models;

namespace ThePixeler.Services.Authorization;

public enum RoomRole
{
    Dono,
    Adm,
    Pintor,
    Plateia
}

public interface IAuthorizationService
{
    Task<RoomRole> GetRole(int roleId);
}