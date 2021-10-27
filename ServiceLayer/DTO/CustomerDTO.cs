using System;
namespace ServiceLayer.DTO
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string EMail { get; set; }
        public int Orders { get; set; }
        public int id { get; set; }
    }
}