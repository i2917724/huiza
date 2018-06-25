
namespace Huiza.Models
{
    using System;
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string image { get; set; }
        public Int16 stock { get; set; } // --> mysql smallint => int16
        public string characteristics { get; set; }
        public string description { get; set; }
        public string category_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Category category { get; set; }
    }
}