﻿namespace BrightFocus.Core.Models.Customers
{
    public class CustomerModel
    {
        public virtual Guid EntityId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}