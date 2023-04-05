using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelProje.Models.Sınıflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen bir Başlık girin.")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Lütfen bir Tarih giriniz.")]
        public DateTime Tarih { get; set; }

        [StringLength(100000, ErrorMessage = "Açıklama en az 250 en fazla 950 karakter olabilir.", MinimumLength = 250)]
        [Required(ErrorMessage = "Lütfen bir Açıklama girin.")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Lütfen bir Fotoğraf Url'si girin.")]
        public string BlogImage { get; set; }

        public ICollection<Yorumlar> Yorumlars { get; set; }

        

    }
}