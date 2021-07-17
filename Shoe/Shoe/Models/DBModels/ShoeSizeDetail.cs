using System;
using System.Collections.Generic;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class ShoeSizeDetail
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? SizeId { get; set; }
        public int? Quatity { get; set; }
        public int? QuabtilySale { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
