namespace qaacGUI
{
    partial class RunningStatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.datagB = new System.Windows.Forms.GroupBox();
            this.estETADataTB = new System.Windows.Forms.TextBox();
            this.estETALabel = new System.Windows.Forms.Label();
            this.currentPositionLabel = new System.Windows.Forms.Label();
            this.fpsDataTB = new System.Windows.Forms.TextBox();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.currentPostionDataTB = new System.Windows.Forms.TextBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.filesCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.stopBtn = new System.Windows.Forms.Button();
            this.datagB.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagB
            // 
            this.datagB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagB.Controls.Add(this.estETADataTB);
            this.datagB.Controls.Add(this.estETALabel);
            this.datagB.Controls.Add(this.currentPositionLabel);
            this.datagB.Controls.Add(this.fpsDataTB);
            this.datagB.Controls.Add(this.fpsLabel);
            this.datagB.Controls.Add(this.currentPostionDataTB);
            this.datagB.Location = new System.Drawing.Point(12, 5);
            this.datagB.Name = "datagB";
            this.datagB.Size = new System.Drawing.Size(277, 109);
            this.datagB.TabIndex = 4;
            this.datagB.TabStop = false;
            // 
            // estETADataTB
            // 
            this.estETADataTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.estETADataTB.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.estETADataTB.Location = new System.Drawing.Point(113, 73);
            this.estETADataTB.Name = "estETADataTB";
            this.estETADataTB.ReadOnly = true;
            this.estETADataTB.Size = new System.Drawing.Size(158, 25);
            this.estETADataTB.TabIndex = 21;
            this.estETADataTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // estETALabel
            // 
            this.estETALabel.AutoSize = true;
            this.estETALabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.estETALabel.Location = new System.Drawing.Point(8, 79);
            this.estETALabel.Name = "estETALabel";
            this.estETALabel.Size = new System.Drawing.Size(80, 17);
            this.estETALabel.TabIndex = 6;
            this.estETALabel.Text = "预计剩余时间";
            // 
            // currentPositionLabel
            // 
            this.currentPositionLabel.AutoSize = true;
            this.currentPositionLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentPositionLabel.Location = new System.Drawing.Point(8, 23);
            this.currentPositionLabel.Name = "currentPositionLabel";
            this.currentPositionLabel.Size = new System.Drawing.Size(73, 17);
            this.currentPositionLabel.TabIndex = 0;
            this.currentPositionLabel.Text = "已完成/总计";
            // 
            // fpsDataTB
            // 
            this.fpsDataTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpsDataTB.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpsDataTB.Location = new System.Drawing.Point(113, 45);
            this.fpsDataTB.Name = "fpsDataTB";
            this.fpsDataTB.ReadOnly = true;
            this.fpsDataTB.Size = new System.Drawing.Size(158, 25);
            this.fpsDataTB.TabIndex = 17;
            this.fpsDataTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpsLabel.Location = new System.Drawing.Point(8, 50);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(56, 17);
            this.fpsLabel.TabIndex = 2;
            this.fpsLabel.Text = "编码速度";
            // 
            // currentPostionDataTB
            // 
            this.currentPostionDataTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPostionDataTB.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentPostionDataTB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.currentPostionDataTB.Location = new System.Drawing.Point(113, 18);
            this.currentPostionDataTB.Name = "currentPostionDataTB";
            this.currentPostionDataTB.ReadOnly = true;
            this.currentPostionDataTB.Size = new System.Drawing.Size(158, 25);
            this.currentPostionDataTB.TabIndex = 15;
            this.currentPostionDataTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(12, 120);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(271, 23);
            this.progress.TabIndex = 5;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("苹方 中等", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.progressLabel.Location = new System.Drawing.Point(233, 152);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(56, 21);
            this.progressLabel.TabIndex = 6;
            this.progressLabel.Text = "0.00%";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.filesCountLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 181);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(301, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "状态: ";
            // 
            // filesCountLabel
            // 
            this.filesCountLabel.Name = "filesCountLabel";
            this.filesCountLabel.Size = new System.Drawing.Size(34, 17);
            this.filesCountLabel.Text = "0/12";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(336, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 0);
            this.textBox1.TabIndex = 9;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(12, 149);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(64, 24);
            this.stopBtn.TabIndex = 10;
            this.stopBtn.Text = "中止";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // RunningStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 203);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.datagB);
            this.MaximumSize = new System.Drawing.Size(317, 242);
            this.MinimumSize = new System.Drawing.Size(317, 242);
            this.Name = "RunningStatusForm";
            this.Text = "正在转换";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RunningStatusForm_FormClosed);
            this.datagB.ResumeLayout(false);
            this.datagB.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox datagB;
        private System.Windows.Forms.TextBox estETADataTB;
        private System.Windows.Forms.Label estETALabel;
        private System.Windows.Forms.Label currentPositionLabel;
        private System.Windows.Forms.TextBox fpsDataTB;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.TextBox currentPostionDataTB;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.ToolStripStatusLabel filesCountLabel;

    }
}