﻿namespace LuresWebLib.Domain
{
    public class Lure
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int Inventory { get; set; }
        public int Caught { get; set; }
        public string Description { get; set; }
        public string RawImage { get; set; }
   
    }
}