using ThePixeler.Models;

namespace ThePixeler.Services.Role;

public enum RoomRole
{
    Dono,
    Adm,
    Pintor,
    Plateia
}

public interface IRoleService
{
    Task<RoomRole> GetRole(int roleId);

}