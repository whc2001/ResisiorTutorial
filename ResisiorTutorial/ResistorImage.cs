using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ResisiorTutorial
{
    public partial class ResistorImage : UserControl
    {
        private Color[] bands;
        private Label[] bandLabels;
        public ResistorImage()
        {
            InitializeComponent();
            bandLabels = new Label[]
            {
                lblBand1,
                lblBand2,
                lblBand3,
                lblBand4,
                lblBand5
            };

        }

        private void ResistorImage_Load(object sender, EventArgs e)
        {
            
        }

        public void UpdateBand(Color[] bands)
        {
            this.bands = bands;
            for(int i = 0;i < bandLabels.Length;i++)
            {
                bandLabels[i].BackColor = this.bands[i];
            }
        }
    }
}
