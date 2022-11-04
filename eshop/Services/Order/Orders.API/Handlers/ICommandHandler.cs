using Orders.API.Commands;

namespace Orders.API.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);

    }

}
