using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FifthAve.Api.Controllers.Api.Base
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected BaseController(IMediator mediator) 
            => _mediator = mediator;

        protected Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken) where TResponse : class
            => _mediator.Send(request, cancellationToken);

        protected Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken) where TNotification : class
            => _mediator.Publish(notification, cancellationToken);
    }
}
