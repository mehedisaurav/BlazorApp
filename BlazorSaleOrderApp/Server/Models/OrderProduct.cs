﻿namespace BlazorSaleOrderApp.Server.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }

    }
}
