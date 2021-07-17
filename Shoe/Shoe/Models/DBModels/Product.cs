using System;
using System.Collections.Generic;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderDetails = new HashSet<OrderDetail>();
            ShoeSizeDetails = new HashSet<ShoeSizeDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public string Discription { get; set; }
        public int CategoryId { get; set; }
        public string MainImg { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ShoeSizeDetail> ShoeSizeDetails { get; set; }
    }
}
