using Next3.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Next3.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
