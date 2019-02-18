namespace Next3.Application.EventSourcerNormalizers
{
    public class ProductHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string RestaurantId { get; set; }
        public string CategoryId { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
