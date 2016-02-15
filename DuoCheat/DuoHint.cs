using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoCheat
{
    public class DuoHint
    {
        public DuoHint()
        {
            tokens = new List<HintToken>();
        }

        public List<HintToken> tokens { get; set; }
    }


    public class HintToken
    {
        public HintTable hint_table { get; set; }
        public int index { get; set; }
    }


    public class HintTable
    {
        public HintTable()
        {
            rows = new List<HintRow>();
        }

        public List<HintRow> rows { get; set; }
    }


    public class HintRow
    {
        public HintRow()
        {
            cells = new List<HintCell>();
        }

        public List<HintCell> cells { get; set; }
    }


    public class HintCell
    {
        public string hint { get; set; }
    }
}
