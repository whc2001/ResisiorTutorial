using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ResisiorTutorial
{
    public partial class ResistorKeypad : UserControl
    {
        private List<Color> colors;
        private StringBuilder sb;

        public event Action<Color[]> OnConfirm;

        public ResistorKeypad()
        {
            InitializeComponent();
            colors = new List<Color>();
            sb = new StringBuilder();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colors.Add(((Button)sender).ForeColor);
            sb.Append(((Button)sender).Text);
            txtInput.Text = sb.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (colors.Count > 0)
            {
                colors.RemoveAt(colors.Count - 1);
                sb.Remove(sb.Length - 1, 1);
                txtInput.Text = sb.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            colors = new List<Color>();
            sb = new StringBuilder();
            txtInput.Text = sb.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            OnConfirm?.Invoke(colors.ToArray());
            btnClear.PerformClick();
        }
    }
}
