using Newtonsoft.Json;
using Next3.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Next3.Application.EventSourcerNormalizers
{
    public class RestaurantHistory
    {
        public static IList<RestaurantHistoryData> HistoryData { get; set; }

        public static IList<RestaurantHistoryData> ToJavaScriptRestaurantHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<RestaurantHistoryData>();
            RestaurantHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<RestaurantHistoryData>();
            var last = new RestaurantHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new RestaurantHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Description = string.IsNullOrWhiteSpace(change.Description) || change.Description == last.Description
                        ? ""
                        : change.Description,
                    IsActive = string.IsNullOrWhiteSpace(change.IsActive) || change.IsActive == last.IsActive
                        ? ""
                        : change.IsActive,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void RestaurantHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new RestaurantHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "RestaurantRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.IsActive = values["IsActive"];
                        slot.Description = values["Description"];
                        slot.Name = values["Name"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "RestaurantUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.IsActive = values["IsActive"];
                        slot.Description = values["Description"];
                        slot.Name = values["Name"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "RestaurantRemovedEvent":
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
