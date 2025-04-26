using Shopping.Application.CQRS.Core;

namespace Shopping.Application.Mediator;

public interface IMediator
{
    Task<TResult> SendAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
}