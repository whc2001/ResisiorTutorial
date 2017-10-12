namespace ResisiorTutorial
{
    partial class frmStart
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnColorToValue = new System.Windows.Forms.Button();
            this.btnValueToColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnColorToValue
            // 
            this.btnColorToValue.Location = new System.Drawing.Point(53, 12);
            this.btnColorToValue.Name = "btnColorToValue";
            this.btnColorToValue.Size = new System.Drawing.Size(172, 61);
            this.btnColorToValue.TabIndex = 0;
            this.btnColorToValue.Text = "颜色到阻值";
            this.btnColorToValue.UseVisualStyleBackColor = true;
            this.btnColorToValue.Click += new System.EventHandler(this.btnColorToValue_Click);
            // 
            // btnValueToColor
            // 
            this.btnValueToColor.Location = new System.Drawing.Point(53, 79);
            this.btnValueToColor.Name = "btnValueToColor";
            this.btnValueToColor.Size = new System.Drawing.Size(172, 61);
            this.btnValueToColor.TabIndex = 1;
            this.btnValueToColor.Text = "阻值到颜色";
            this.btnValueToColor.UseVisualStyleBackColor = true;
            this.btnValueToColor.Click += new System.EventHandler(this.btnValueToColor_Click);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 157);
            this.Controls.Add(this.btnValueToColor);
            this.Controls.Add(this.btnColorToValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStart";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnColorToValue;
        private System.Windows.Forms.Button btnValueToColor;
    }
}

