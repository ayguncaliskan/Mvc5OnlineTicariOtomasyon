﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc5OnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int Faturaid { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSerino { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSırano { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }
        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }



    }
}