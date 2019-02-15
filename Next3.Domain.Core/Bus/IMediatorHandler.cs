using Next3.Domain.Core.Commands;
using Next3.Domain.Core.Events;
using System.Threading.Tasks;

namespace Next3.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
