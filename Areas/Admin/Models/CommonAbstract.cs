﻿namespace WebsiteTMDT.Areas.Admin.Models
{
    public class CommonAbstract
    {
        public string? CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifierDate { get; set; }
        public string? ModifierBy { get; set; }
    }
}
