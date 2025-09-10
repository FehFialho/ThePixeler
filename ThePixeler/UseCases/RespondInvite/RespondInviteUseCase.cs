using ThePixeler.EndPoints.DTOs;
using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;

namespace ThePixeler.UseCases.RespondInvite;

public class RespondInviteUseCase (
    EFExtractJWTData extractJWTData,
    ThePixelerDbContext ctx
    )
{
    public async Task<Result<RespondInviteResponse>> Do(RespondInviteDTO dto)
    {
        
        // Sempre confere os nulls após procurar itens no DB
        
        var invite = await ctx.Invites.FindAsync(dto.inviteId);
        if (invite == null)
            return Result<RespondInviteResponse>.Fail("Invite not found");

        var room = await ctx.Rooms.FindAsync(dto.roomID);
        if (room == null)
            return Result<RespondInviteResponse>.Fail("Room not found");

        var user = await ctx.Users.FindAsync(dto.userID);
        if (user == null)
            return Result<RespondInviteResponse>.Fail("Erro no Token");

        var sender = await ctx.Users.FindAsync(invite.SenderID);
        if (sender == null)
            return Result<RespondInviteResponse>.Fail("Sender not found");

        // Se a resposta for true, adicionar a sala na lista do User!
        if (dto.response)
            user.Rooms.Add(room);

        // Independente da resposta, remover o convite.
        user.InvitesReceived.Remove(invite);
        sender.InvitesSended.Remove(invite);

        await ctx.SaveChangesAsync(); // Não esquecer de salvar as alterações!

        return Result<RespondInviteResponse>.Success(null);
    }
}