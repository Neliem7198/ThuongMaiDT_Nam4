using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_BookStore.Models.Temp
{
    public class HistoryView
    {
        public List<temp> children { get; set; }

        public HistoryView() { children = new List<temp>(); }

        public class temp : IComparable<temp>
        {
            public string Name { get; set; }
            public double Count { get; set; }
            public double SoLuong { get; set; }
            public string id { get; set; }

            public temp(string name, double counts, int sl, string id)
            {
                Name = name; Count = counts; SoLuong = sl; this.id = id;
            }
            public int CompareTo(temp other)
            {
                return other.Count.CompareTo(Count);
            }
        }
    }
}