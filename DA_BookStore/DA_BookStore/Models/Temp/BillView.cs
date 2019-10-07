using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_BookStore.Models.Temp
{
    public class BillView : IComparable<BillView>
    {
        public int month { get; set; }
        public List<v> values { get; set; }

        public class v
        {
            public int value { get; set; }
            public string rate { get; set; }

            public v(string rate)
            {
                value = 1; this.rate = rate;
            }
        }

        public BillView(int month, string rate)
        {
            values = new List<v>();
            this.month = month;
            values.Add(new v(rate));
        }

        public void addValue(string rate)
        {
            bool flag = false;
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].rate == rate)
                {
                    values[i].value += 1;
                    flag = !flag;
                    break;
                }
            }
            if (!flag)
                values.Add(new v(rate));
        }

        public int CompareTo(BillView another)
        {
            return month.CompareTo(another.month);
        }

    }
}