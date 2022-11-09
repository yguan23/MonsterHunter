using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace prjCore.Models
{
    public partial class Monster
    {
        public int Id { get; set; }
        public string 名稱 { get; set; }
        public string 種類 { get; set; }
        public string 弱點武器 { get; set; }
        public string 弱點部位 { get; set; }
        public string 弱點屬性 { get; set; }
    }
}
