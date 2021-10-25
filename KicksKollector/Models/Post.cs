using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KicksKollector.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public string StyleCode { get; set; }

        public int Quantity { get; set; }

        public int PurchasePrice { get; set; }

        public int SoldPrice { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int UserProfileId { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
    

