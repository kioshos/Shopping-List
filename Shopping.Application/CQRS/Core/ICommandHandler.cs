namespace Shopping.Application.CQRS.Core;

public interface ICommandHandler<TCommand> 
    where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}