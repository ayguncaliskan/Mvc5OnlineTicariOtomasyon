using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5OnlineTicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }

        [StringLength(200)]
        public string urunad { get; set; }

        [StringLength(2000)]
        public string urunbilgi { get; set; }
    }
}