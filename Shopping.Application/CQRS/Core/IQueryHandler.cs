namespace Shopping.Application.CQRS.Core;

public interface IQueryHandler<TQuery, TResult> 
    where TQuery : IQuery
{
    Task<TResult> HandleAsync(TQuery query);
}