using ThePixeler.Models;
namespace ThePixeler.UseCases.GetMembers;

public record GetMembersResponse(
    ICollection<User> Members
);