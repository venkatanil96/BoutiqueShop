using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoutiqueShop.Models
{
    public class Dress
    {
        public int DressID { get; set; }
        public string DressName { get; set; }
        public string DressPrice { get; set; }
        public int ShopId { get; set; }
    }
}