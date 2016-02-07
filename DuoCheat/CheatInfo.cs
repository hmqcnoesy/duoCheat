using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoCheat
{
    public class CheatInfo
    {
        public List<SessionElement> session_elements;
        public CheatInfo()
        {
            session_elements = new List<SessionElement>();
        }
    }

    public class SessionElement
    {
        public string translation { get; set; }
        public string text { get; set; }
    }
}
