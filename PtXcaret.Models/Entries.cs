using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PtXcaret.Models
{
    public class Entries
    {
        public int Count { get; set; }
        public IList<ItemEntries> entries { get; set; }
    }
}

