using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ResisiorTutorial
{
    public partial class frmColorToValue : Form
    {
        private Form parent;
        private int questionCount = 0;
        private DateTime startTime;
        private DateTime questionStartTime;
        private int lastQuestionCostTime = -1;
        private Color[] questionValue;
        private long questionAnswer;
        private bool errorFlag = false;
        private int correctCount = 0;

        public frmColorToValue(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void frmColorToValue_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void NewQuestion()
        {
            questionCount++;
            questionStartTime = DateTime.Now;
            questionAnswer = ResistorValues.GetRandom();
            List<Color> l = new List<Color>();
            l.AddRange(ResistorHelper.GetColorFromValue(questionAnswer, true));
            l.Add(Color.Gold);
            questionValue = l.ToArray();
            resistorImage1.UpdateBand(questionValue);
            txtAnswer.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Hide();
            panMain.Show();
            startTime = DateTime.Now;
            timer1.Start();
            NewQuestion();
        }

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                long answer = 0;
                try
                {
                    answer = ResistorHelper.ExpressToValue(txtAnswer.Text);
                }
                catch
                {
                    errorProvider1.BlinkRate = 100;
                    errorProvider1.SetError(txtAnswer, "输入有误!");
                    errorFlag = true;
                    txtAnswer.Text = "";
                    return;
                }
                if (answer == questionAnswer)
                {
                    errorProvider1.Clear();
                    lastQuestionCostTime = (DateTime.Now - questionStartTime).Seconds;
                    if (!errorFlag)
                        correctCount++;
                    txtAnswer.Text = "";
                    NewQuestion();
                }
                else
                {
                    errorProvider1.BlinkRate = 100;
                    errorProvider1.SetError(txtAnswer, "答案错误!");
                    errorFlag = true;
                    txtAnswer.Text = "";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = String.Format("总计时间 {0}s  上题时间  {1}s  总计题数 {2}  做对题数 {3}", (DateTime.Now - startTime).Seconds, lastQuestionCostTime == -1 ? "-" : lastQuestionCostTime.ToString(), questionCount, correctCount);
        }
    }
}
