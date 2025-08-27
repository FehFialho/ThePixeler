using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;
using ThePixeler.Services.JWT;
using ThePixeler.Services.Role;

namespace ThePixeler.UseCases.EditMember;

public class EditMemberUseCase(
    IExtractJWTData extractJWTData,
    IRoleService roleService,
    ThePixelerDbContext ctx
)
{
    public async Task<Result<EditMemberResponse>> Do(EditMemberPayload payload)
    {

        // Target
        var targetID = payload.TargetID;
        var target = await ctx.RoomUsers.FindAsync(targetID);
        // Pegar Roles
        var targetRoleID = target.RoleID;
        var targetRole = await roleService.GetRole(targetRoleID);

        // Pegar o usuário para ver se ele pode mudar o cargo.
        var userID = await extractJWTData.GetUserGuid(payload.HttpContext);
        var roomuser = await ctx.RoomUsers.FindAsync(userID);
        // Pegar Roles
        var roleID = roomuser.RoleID;
        var role = await roleService.GetRole(roleID);

        // Condicional
        if ((int)role <= (int)targetRole)
            return Result<EditMemberResponse>.Fail("Seu cargo precisa ser maior!");

        target.Role = payload.NewRole;
        return Result<EditMemberResponse>.Success(null);
    }
}