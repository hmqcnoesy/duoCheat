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
        public SessionElement()
        {
            correct_solutions = new List<string>();
            options = new List<AnswerOption>();
            form_tokens = new List<FormToken>();
        }

        public string translation { get; set; }
        public string text { get; set; }
        public List<string> correct_solutions { get; set; }
        public List<AnswerOption> options { get; set; }
        public List<FormToken> form_tokens { get; set; }
    }


    public class AnswerOption
    {
        public bool correct { get; set; }
        public string sentence { get; set; }
    }


    public class FormToken
    {
        public FormToken()
        {
            options = new List<FormTokenOption>();
        }

        public List<FormTokenOption> options { get; set; }
    }


    public class FormTokenOption
    {
        public bool correct { get; set; }
        public string display_value { get; set; }
    }
}
