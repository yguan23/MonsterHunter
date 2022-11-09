using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace prjCore.Models
{
    public partial class Armor
    {
        public int Id { get; set; }
        public string 系列名稱 { get; set; }
        public int? 頭盔 { get; set; }
        public int? 鎧甲 { get; set; }
        public int? 腕甲 { get; set; }
        public int? 腰甲 { get; set; }
        public int? 護腿 { get; set; }
    }
}
