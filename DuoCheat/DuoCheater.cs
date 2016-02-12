using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DuoCheat
{
    public class DuoCheater : Fiddler.IFiddlerExtension, Fiddler.IAutoTamper
    {
        public bool Enabled { get; set; }
        private DuoCheaterUserControl _userControl;


        public void AutoTamperRequestAfter(Session oSession)
        {
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
        }

        public void AutoTamperResponseAfter(Session session)
        {
            if (!Enabled) return;
            if (session.oRequest.host != "www.duolingo.com") return;
            if (!session.oResponse.MIMEType.StartsWith("application/json")) return;

            session.utilDecodeResponse();

            var responseString = System.Text.Encoding.UTF8.GetString(session.ResponseBody);

            try
            {
                var cheatInfo = JsonConvert.DeserializeObject<CheatInfo>(responseString);
                if (cheatInfo.session_elements.Count == 0) return;

                _userControl.AppendText(string.Empty);
                _userControl.ResetCount();

                foreach(var element in cheatInfo.session_elements)
                {
                    if (element.form_tokens.Count(t => t.options.Count > 0) > 0) _userControl.AppendText(element.form_tokens.First(f => f.options.Count > 0).options.First(o => o.correct).display_value);
                    else if (element.options.Count > 0) _userControl.AppendText(string.Join(" / ", element.options.Where(o => o.correct).Select(o => o.sentence)));
                    else if (!string.IsNullOrEmpty(element.translation)) _userControl.AppendText(element.translation);
                    else if (!string.IsNullOrEmpty(element.text)) _userControl.AppendText(element.text);
                    else if (element.correct_solutions.Count > 0) _userControl.AppendText(element.correct_solutions[0]);
                    else _userControl.AppendText("?");
                }
            }
            finally
            {
            }
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
        }

        public void OnBeforeReturningError(Session oSession)
        {
        }

        public void OnBeforeUnload()
        {
        }

        public void OnLoad()
        {
            Enabled = false;
            var tabPage = new TabPage("Duo Cheater");
            tabPage.ImageIndex = (int)Fiddler.SessionIcons.Information;
            _userControl = new DuoCheaterUserControl(this);
            tabPage.Controls.Add(_userControl);
            tabPage.Controls[0].Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            Fiddler.FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
        }
    }
}
