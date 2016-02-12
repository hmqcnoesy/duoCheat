using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DuoCheat
{
    public partial class DuoCheaterUserControl : UserControl
    {
        private DuoCheater _parentExtension;
        private int _count = 1;

        public DuoCheaterUserControl(DuoCheater parent)
        {
            InitializeComponent();
            _parentExtension = parent;
        }


        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _parentExtension.Enabled = chkEnabled.Checked;
        }


        public void AppendText(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                txtCheatInfo.AppendText("\r\n");
            }
            else
            {
                txtCheatInfo.AppendText(_count.ToString() + ".  " + value);
                if (!value.EndsWith("\r\n")) txtCheatInfo.AppendText("\r\n");
                _count++;
            }

            txtCheatInfo.SelectionStart = txtCheatInfo.Text.Length;
            txtCheatInfo.ScrollToCaret();
        }


        public void ResetCount()
        {
            _count = 1;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCheatInfo.Clear();
        }
    }
}
