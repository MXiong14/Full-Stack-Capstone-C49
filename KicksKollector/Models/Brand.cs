using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KicksKollector.Models
{
    public class Brand
    {
            public int Id { get; set; }

            [Required]
            public string SubBrand { get; set; }
        
    }
}
