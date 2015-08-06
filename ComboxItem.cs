using System;
using System.Collections.Generic;
using System.Text;

namespace Print
{
    class ComboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public ComboxItem()
        { 
        
        }
        public ComboxItem(string a, string b)
        {
            Text = b;
            Value = a;
        }

        public override string ToString()
        {
            return Text;
        }

    }
}
