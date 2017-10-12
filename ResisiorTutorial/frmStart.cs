using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ResisiorTutorial
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnValueToColor_Click(object sender, EventArgs e)
        {
            new frmValueToColor(this).Show();
            this.Hide();
        }

        private void btnColorToValue_Click(object sender, EventArgs e)
        {
            new frmColorToValue(this).Show();
            this.Hide();
        }
    }
}
