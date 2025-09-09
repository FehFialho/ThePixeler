namespace ThePixeler.UseCases.Login;

public record LoginPayload(
    string Login,
    string Password
);