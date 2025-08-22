using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThePixeler.Services.IPasswordServices;
using ThePixeler.Services.JWT;
using ThePixeler.Services.Profiles;

namespace ThePixeler.UseCases.Login;

public class LoginUseCase(
    IProfilesService profilesService,
    IPasswordService passwordService,
    IJWTService jwtService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profilesService.FindByLogin(payload.Login);

        // Se o usuário for null, retorna Fail com mensagem
        if (user is null)
            return Result<LoginResponse>.Fail("User not found!");

        // Passa os dois valores do payload para o serviço comparar
        var passwordMatch = passwordService
            .Compare(payload.Password, user.Password);

        // Se o computador não der match, envia erro.
        if (!passwordMatch)
            return Result<LoginResponse>.Fail("Wrong Password!");

        // 
        var jwt = jwtService.CreateToken(new(
            user.ID, user.Username, user.SubscriptionID
        ));

        // Se tudo der certo, retorna o JWT
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}