using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_BookStore.Models.Temp
{
    public class GroupCusView
    {
        public string theloai { get; set; }
        public string group { get; set; }
        public int count { get; set; }
        public GroupCusView(string gr, string tl, int c)
        {
            group = gr; theloai = tl; count = c;
        }
    }
}