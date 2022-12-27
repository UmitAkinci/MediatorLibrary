namespace MediatorLibrarySample.CQRS
{
    public interface IAdessoPipelineBehavior<in TRequest, TResponse> where TRequest : IAdessoRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
    }
}