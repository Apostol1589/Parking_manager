using Microsoft.Extensions.Logging;

namespace ParkingManager.BusinessLogic.ChainOfResponsibility
{
    public abstract class Handler<T> : IHandler<T>
    {
        protected IHandler<T>? NextHandler;
        protected ILogger Logger;

        protected Handler(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger(typeof(T));
        }

        public IHandler<T> SetNext(IHandler<T> handler)
        {
            NextHandler = handler;
            return handler;
        }

        public virtual void Handle(T request)
        {
            if (NextHandler != null)
            {
                NextHandler.Handle(request);
            }
        }
    }
}
