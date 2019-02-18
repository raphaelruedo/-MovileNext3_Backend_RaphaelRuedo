using Newtonsoft.Json;
using Next3.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Next3.Application.EventSourcerNormalizers
{
    public class ProductHistory
    {
        public static IList<ProductHistoryData> HistoryData { get; set; }

        public static IList<ProductHistoryData> ToJavaScriptProductHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ProductHistoryData>();
            ProductHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<ProductHistoryData>();
            var last = new ProductHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ProductHistoryData
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
                    Price = string.IsNullOrWhiteSpace(change.Price) || change.Price == last.Price
                        ? ""
                        : change.Price,
                    RestaurantId = string.IsNullOrWhiteSpace(change.RestaurantId) || change.RestaurantId == last.RestaurantId
                        ? ""
                        : change.RestaurantId,
                    CategoryId = string.IsNullOrWhiteSpace(change.CategoryId) || change.CategoryId == last.CategoryId
                        ? ""
                        : change.CategoryId,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ProductHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new ProductHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "ProductRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Price = values["Price"];
                        slot.Description = values["Description"];
                        slot.Name = values["Name"];
                        slot.RestaurantId = values["RestaurantId"];
                        slot.CategoryId = values["CategoryId"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "ProductUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Price = values["Price"];
                        slot.Description = values["Description"];
                        slot.Name = values["Name"];
                        slot.RestaurantId = values["RestaurantId"];
                        slot.CategoryId = values["CategoryId"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "ProductRemovedEvent":
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
