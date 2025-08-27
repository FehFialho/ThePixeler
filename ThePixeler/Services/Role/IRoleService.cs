using ThePixeler.Models;

namespace ThePixeler.Services.Role;

public enum RoomRole
{
    Dono = 4,
    Adm = 3,
    Pintor = 2,
    Plateia = 1
}

public interface IRoleService
{
    Task<RoomRole> GetRole(int roleId);

}