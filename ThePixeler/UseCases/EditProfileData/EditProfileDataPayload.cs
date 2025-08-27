namespace ThePixeler.UseCases.EditProfileData;

public record EditProfileDataPayload(
    string UserName,
    string Token,
    HttpContext HttpContext
);
    
