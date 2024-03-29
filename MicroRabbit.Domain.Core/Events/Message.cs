using MediatR;


namespace MicroRabbit.Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        protected Message(string messageType)
        {
            MessageType = GetType().Name;
        }
    }
}
