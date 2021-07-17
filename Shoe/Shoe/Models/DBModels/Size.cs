using System;
using System.Collections.Generic;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class Size
    {
        public Size()
        {
            ShoeSizeDetails = new HashSet<ShoeSizeDetail>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public virtual ICollection<ShoeSizeDetail> ShoeSizeDetails { get; set; }
    }
}
