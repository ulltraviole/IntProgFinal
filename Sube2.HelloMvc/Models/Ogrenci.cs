﻿namespace Sube2.HelloMvc.Models
{
    public class Ogrenci
    {
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Numara { get; set; }
        public ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}
