namespace qaacGUI
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.fileListlB = new System.Windows.Forms.ListBox();
            this.addFileBtn = new System.Windows.Forms.Button();
            this.addFolderBtn = new System.Windows.Forms.Button();
            this.removeFileBtn = new System.Windows.Forms.Button();
            this.removeAllBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.paraSetgB = new System.Windows.Forms.GroupBox();
            this.profileCB = new System.Windows.Forms.ComboBox();
            this.profileLabel = new System.Windows.Forms.Label();
            this.brORqCB = new System.Windows.Forms.ComboBox();
            this.brORqLabel = new System.Windows.Forms.Label();
            this.isAutoALACcB = new System.Windows.Forms.CheckBox();
            this.codecModeCB = new System.Windows.Forms.ComboBox();
            this.codecModeLabel = new System.Windows.Forms.Label();
            this.outputPathTB = new System.Windows.Forms.TextBox();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.chooseOutputPathBtn = new System.Windows.Forms.Button();
            this.paraSetgB.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileListlB
            // 
            this.fileListlB.AllowDrop = true;
            this.fileListlB.FormattingEnabled = true;
            this.fileListlB.ItemHeight = 12;
            this.fileListlB.Location = new System.Drawing.Point(12, 13);
            this.fileListlB.Name = "fileListlB";
            this.fileListlB.Size = new System.Drawing.Size(314, 136);
            this.fileListlB.TabIndex = 0;
            this.fileListlB.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileListlB_DragDrop);
            this.fileListlB.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileListlB_DragEnter);
            // 
            // addFileBtn
            // 
            this.addFileBtn.Location = new System.Drawing.Point(332, 12);
            this.addFileBtn.Name = "addFileBtn";
            this.addFileBtn.Size = new System.Drawing.Size(75, 23);
            this.addFileBtn.TabIndex = 1;
            this.addFileBtn.Text = "添加文件";
            this.addFileBtn.UseVisualStyleBackColor = true;
            this.addFileBtn.Click += new System.EventHandler(this.addFileBtn_Click);
            // 
            // addFolderBtn
            // 
            this.addFolderBtn.Location = new System.Drawing.Point(332, 41);
            this.addFolderBtn.Name = "addFolderBtn";
            this.addFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.addFolderBtn.TabIndex = 2;
            this.addFolderBtn.Text = "添加文件夹";
            this.addFolderBtn.UseVisualStyleBackColor = true;
            this.addFolderBtn.Click += new System.EventHandler(this.addFolderBtn_Click);
            // 
            // removeFileBtn
            // 
            this.removeFileBtn.Location = new System.Drawing.Point(332, 97);
            this.removeFileBtn.Name = "removeFileBtn";
            this.removeFileBtn.Size = new System.Drawing.Size(75, 23);
            this.removeFileBtn.TabIndex = 3;
            this.removeFileBtn.Text = "移除文件";
            this.removeFileBtn.UseVisualStyleBackColor = true;
            this.removeFileBtn.Click += new System.EventHandler(this.removeFileBtn_Click);
            // 
            // removeAllBtn
            // 
            this.removeAllBtn.Location = new System.Drawing.Point(332, 126);
            this.removeAllBtn.Name = "removeAllBtn";
            this.removeAllBtn.Size = new System.Drawing.Size(75, 23);
            this.removeAllBtn.TabIndex = 4;
            this.removeAllBtn.Text = "移除所有";
            this.removeAllBtn.UseVisualStyleBackColor = true;
            this.removeAllBtn.Click += new System.EventHandler(this.removeAllBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("宋体", 9F);
            this.startBtn.Location = new System.Drawing.Point(332, 303);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "开始转换";
            this.startBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // paraSetgB
            // 
            this.paraSetgB.Controls.Add(this.profileCB);
            this.paraSetgB.Controls.Add(this.profileLabel);
            this.paraSetgB.Controls.Add(this.brORqCB);
            this.paraSetgB.Controls.Add(this.brORqLabel);
            this.paraSetgB.Controls.Add(this.isAutoALACcB);
            this.paraSetgB.Controls.Add(this.codecModeCB);
            this.paraSetgB.Controls.Add(this.codecModeLabel);
            this.paraSetgB.Location = new System.Drawing.Point(12, 189);
            this.paraSetgB.Name = "paraSetgB";
            this.paraSetgB.Size = new System.Drawing.Size(314, 137);
            this.paraSetgB.TabIndex = 6;
            this.paraSetgB.TabStop = false;
            this.paraSetgB.Text = "参数设置";
            // 
            // profileCB
            // 
            this.profileCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileCB.FormattingEnabled = true;
            this.profileCB.Items.AddRange(new object[] {
            "LC-ACC",
            "HE-AAC"});
            this.profileCB.Location = new System.Drawing.Point(118, 52);
            this.profileCB.Name = "profileCB";
            this.profileCB.Size = new System.Drawing.Size(110, 20);
            this.profileCB.TabIndex = 6;
            this.profileCB.SelectedIndexChanged += new System.EventHandler(this.profileCB_SelectedIndexChanged);
            // 
            // profileLabel
            // 
            this.profileLabel.AutoSize = true;
            this.profileLabel.Location = new System.Drawing.Point(58, 55);
            this.profileLabel.Name = "profileLabel";
            this.profileLabel.Size = new System.Drawing.Size(47, 12);
            this.profileLabel.TabIndex = 5;
            this.profileLabel.Text = "Profile";
            // 
            // brORqCB
            // 
            this.brORqCB.FormattingEnabled = true;
            this.brORqCB.Items.AddRange(new object[] {
            "0",
            "9",
            "18",
            "27",
            "36",
            "45",
            "54",
            "63",
            "73",
            "82",
            "91",
            "100",
            "109",
            "118",
            "127"});
            this.brORqCB.Location = new System.Drawing.Point(118, 104);
            this.brORqCB.Name = "brORqCB";
            this.brORqCB.Size = new System.Drawing.Size(110, 20);
            this.brORqCB.TabIndex = 4;
            this.brORqCB.Text = "91";
            // 
            // brORqLabel
            // 
            this.brORqLabel.AutoSize = true;
            this.brORqLabel.Location = new System.Drawing.Point(58, 107);
            this.brORqLabel.Name = "brORqLabel";
            this.brORqLabel.Size = new System.Drawing.Size(29, 12);
            this.brORqLabel.TabIndex = 3;
            this.brORqLabel.Text = "质量";
            // 
            // isAutoALACcB
            // 
            this.isAutoALACcB.AutoSize = true;
            this.isAutoALACcB.Checked = true;
            this.isAutoALACcB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutoALACcB.Location = new System.Drawing.Point(60, 29);
            this.isAutoALACcB.Name = "isAutoALACcB";
            this.isAutoALACcB.Size = new System.Drawing.Size(168, 16);
            this.isAutoALACcB.TabIndex = 2;
            this.isAutoALACcB.Text = "无损音乐自动使用ALAC编码";
            this.isAutoALACcB.UseVisualStyleBackColor = true;
            // 
            // codecModeCB
            // 
            this.codecModeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codecModeCB.FormattingEnabled = true;
            this.codecModeCB.Items.AddRange(new object[] {
            "CBR",
            "ABR",
            "CVBR",
            "TVBR"});
            this.codecModeCB.Location = new System.Drawing.Point(118, 78);
            this.codecModeCB.Name = "codecModeCB";
            this.codecModeCB.Size = new System.Drawing.Size(110, 20);
            this.codecModeCB.TabIndex = 1;
            this.codecModeCB.SelectedIndexChanged += new System.EventHandler(this.codecModeCB_SelectedIndexChanged);
            // 
            // codecModeLabel
            // 
            this.codecModeLabel.AutoSize = true;
            this.codecModeLabel.Location = new System.Drawing.Point(58, 81);
            this.codecModeLabel.Name = "codecModeLabel";
            this.codecModeLabel.Size = new System.Drawing.Size(53, 12);
            this.codecModeLabel.TabIndex = 0;
            this.codecModeLabel.Text = "编码模式";
            // 
            // outputPathTB
            // 
            this.outputPathTB.Location = new System.Drawing.Point(71, 162);
            this.outputPathTB.Name = "outputPathTB";
            this.outputPathTB.ReadOnly = true;
            this.outputPathTB.Size = new System.Drawing.Size(255, 21);
            this.outputPathTB.TabIndex = 7;
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Location = new System.Drawing.Point(12, 165);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(53, 12);
            this.outputPathLabel.TabIndex = 8;
            this.outputPathLabel.Text = "输出路径";
            // 
            // chooseOutputPathBtn
            // 
            this.chooseOutputPathBtn.Location = new System.Drawing.Point(332, 160);
            this.chooseOutputPathBtn.Name = "chooseOutputPathBtn";
            this.chooseOutputPathBtn.Size = new System.Drawing.Size(75, 23);
            this.chooseOutputPathBtn.TabIndex = 9;
            this.chooseOutputPathBtn.Text = "浏览";
            this.chooseOutputPathBtn.UseVisualStyleBackColor = true;
            this.chooseOutputPathBtn.Click += new System.EventHandler(this.chooseOutputPathBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 338);
            this.Controls.Add(this.chooseOutputPathBtn);
            this.Controls.Add(this.outputPathLabel);
            this.Controls.Add(this.outputPathTB);
            this.Controls.Add(this.paraSetgB);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.removeAllBtn);
            this.Controls.Add(this.removeFileBtn);
            this.Controls.Add(this.addFolderBtn);
            this.Controls.Add(this.addFileBtn);
            this.Controls.Add(this.fileListlB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "qaacGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.paraSetgB.ResumeLayout(false);
            this.paraSetgB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileListlB;
        private System.Windows.Forms.Button addFileBtn;
        private System.Windows.Forms.Button addFolderBtn;
        private System.Windows.Forms.Button removeFileBtn;
        private System.Windows.Forms.Button removeAllBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.GroupBox paraSetgB;
        private System.Windows.Forms.Label codecModeLabel;
        private System.Windows.Forms.ComboBox codecModeCB;
        private System.Windows.Forms.ComboBox profileCB;
        private System.Windows.Forms.Label profileLabel;
        private System.Windows.Forms.ComboBox brORqCB;
        private System.Windows.Forms.Label brORqLabel;
        private System.Windows.Forms.CheckBox isAutoALACcB;
        private System.Windows.Forms.TextBox outputPathTB;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.Button chooseOutputPathBtn;
    }
}

