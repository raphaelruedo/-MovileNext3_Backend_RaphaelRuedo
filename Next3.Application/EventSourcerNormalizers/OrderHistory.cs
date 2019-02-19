using Newtonsoft.Json;
using Next3.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Next3.Application.EventSourcerNormalizers
{
    public class OrderHistory
    {
        public static IList<OrderHistoryData> HistoryData { get; set; }

        public static IList<OrderHistoryData> ToJavaScriptOrderHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<OrderHistoryData>();
            OrderHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<OrderHistoryData>();
            var last = new OrderHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new OrderHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Observation = string.IsNullOrWhiteSpace(change.Observation) || change.Observation == last.Observation
                        ? ""
                        : change.Observation,
                    Address = change.Address.Equals(null) || change.Address == last.Address
                        ? null
                        : change.Address,
                    OrderItens = change.OrderItens.Any() || change.OrderItens == last.OrderItens
                        ? null
                        : change.OrderItens,
                    OrderStatusId = string.IsNullOrWhiteSpace(change.OrderStatusId) || change.OrderStatusId == last.OrderStatusId
                        ? ""
                        : change.OrderStatusId,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void OrderHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new OrderHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "OrderRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Observation = values["Observation"];
                        slot.OrderItens = values["OrderItens"];
                        slot.OrderStatusId = values["OrderStatusId"];
                        slot.Address = values["Address"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "OrderUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Observation = values["Observation"];
                        slot.OrderItens = values["OrderItens"];
                        slot.OrderStatusId = values["OrderStatusId"];
                        slot.Address = values["Address"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "OrderRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
