using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Core;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.Application.CQRS.Handlers;

public class UpdateItemPurchaseStatusCommandHandler : ICommandHandler<UpdateItemPurchaseStatusCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemPurchaseStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task HandleAsync(UpdateItemPurchaseStatusCommand command)
    {
        var item = await _unitOfWork.Item.GetByIdAsync(command.ItemId);

        item.IsPurchased = !item.IsPurchased;

        await _unitOfWork.SaveChangesAsync();
    }
}