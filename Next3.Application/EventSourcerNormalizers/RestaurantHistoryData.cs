﻿namespace Next3.Application.EventSourcerNormalizers
{
    public class RestaurantHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
