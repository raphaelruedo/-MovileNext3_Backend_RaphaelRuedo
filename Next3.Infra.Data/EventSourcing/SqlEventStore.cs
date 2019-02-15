using Newtonsoft.Json;
using Next3.Domain.Core.Events;
using Next3.Infra.Data.Repository.EventSourcing;

namespace Next3.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
