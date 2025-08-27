using Microsoft.EntityFrameworkCore;
using ThePixeler.Models;

namespace ThePixeler.UseCases.GetPlans;

public class GetPlansUseCase (ThePixelerDbContext ctx)
{
    public async Task<Result<GetPlansResponse>> Do(GetPlansPayload payload)
    {

        var plans = await ctx.Subscriptions.ToListAsync();
            
        if (plans == null)
            return Result<GetPlansResponse>.Fail("Não há nenhum plano registrado!");

        return Result<GetPlansResponse>.Success(new(plans));
    }
}