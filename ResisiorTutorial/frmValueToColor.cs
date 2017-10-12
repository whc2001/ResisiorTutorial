using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ResisiorTutorial
{
    public partial class frmValueToColor : Form
    {
        private Form parent;
        private int questionCount = 0;
        private DateTime startTime;
        private DateTime questionStartTime;
        private int lastQuestionCostTime = -1;
        private long questionValue;
        private Color[] questionAnswer;
        private bool errorFlag = false;
        private int correctCount = 0;

        public frmValueToColor(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void frmValueToColor_Load(object sender, EventArgs e)
        {

        }

        private bool CompareColors(Color[] a, Color[] b)
        {
            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        }

        private void NewQuestion()
        {
            questionCount++;
            questionStartTime = DateTime.Now;
            questionValue = ResistorValues.GetRandom();
            List<Color> l = new List<Color>();
            l.AddRange(ResistorHelper.GetColorFromValue(questionValue, true));
            l.Add(Color.Gold);
            questionAnswer = l.ToArray();
            lblValue.Text = ResistorHelper.ValueToExpress(questionValue);
        }

        private void frmValueToColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Hide();
            resistorKeypad1.OnConfirm += ResistorKeypad1_OnConfirm;
            panMain.Show();
            startTime = DateTime.Now;
            timer1.Start();
            NewQuestion();
        }

        private void ResistorKeypad1_OnConfirm(Color[] obj)
        {
            if(CompareColors(questionAnswer, obj))
            {
                errorProvider1.Clear();
                lastQuestionCostTime = (DateTime.Now - questionStartTime).Seconds;
                if (!errorFlag)
                    correctCount++;
                NewQuestion();
            }
            else
            {
                errorProvider1.BlinkRate = 100;
                errorProvider1.SetError(lblValue, "答案错误!");
                errorFlag = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = String.Format("总计时间 {0}s  上题时间  {1}s  总计题数 {2}  做对题数 {3}", (DateTime.Now - startTime).Seconds, lastQuestionCostTime == -1 ? "-" : lastQuestionCostTime.ToString(), questionCount, correctCount);
        }
    }
}
