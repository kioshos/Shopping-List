using Shopping.Application.CQRS.Core;

namespace Shopping.Application.Mediator;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;
    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task<TResponse> SendAsync<TQuery, TResponse>(TQuery query) 
        where TQuery : IQuery
    {
        var handler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResponse>)) 
            as IQueryHandler<TQuery, TResponse>;
        
        if (handler == null) 
            throw new InvalidOperationException($"Handler for {typeof(TQuery)} not found.");
        
        return await handler.HandleAsync(query);
    }

    public async Task SendAsync<TCommand>(TCommand command) 
        where TCommand : ICommand
    {
        var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
        
        if (handler == null) 
            throw new InvalidOperationException($"Handler for {typeof(TCommand)} not found.");

        await handler.HandleAsync(command);
    }
}