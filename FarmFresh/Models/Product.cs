using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace FarmFresh.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; } // Guid(128 bits) take more space than int (32)
        [Required]
        public required string ProductName { get; set; }
        public string? ProductPhoto { get; set; }
        public string? ProductType { get; set; } // Fruit || Meat
        public string? PackingType { get; set; } // Packet
        public bool OnSale { get; set; }
        public bool ShopByStore { get; set; }
        public string? CreatedDate { get; set; }
        public bool Status { get; set; } // Product sold out or not


        //public void Configure(IApplicationBuilder app)
        //{

        //}
    }
}

