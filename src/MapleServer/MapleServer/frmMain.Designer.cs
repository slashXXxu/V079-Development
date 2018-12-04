namespace MapleServer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvServers = new System.Windows.Forms.ListView();
            this._Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._Ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._Connections = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._Rate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtLog = new MapleServer.lib.Control.RollingTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(559, 364);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(551, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "控制台";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(356, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 142);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务端控制";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(36, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "启动服务端";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(36, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "停止服务端";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvServers);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器信息";
            // 
            // lvServers
            // 
            this.lvServers.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._Name,
            this._Ip,
            this._Connections,
            this._Rate});
            this.lvServers.FullRowSelect = true;
            this.lvServers.GridLines = true;
            this.lvServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvServers.HideSelection = false;
            this.lvServers.Location = new System.Drawing.Point(4, 13);
            this.lvServers.Name = "lvServers";
            this.lvServers.Scrollable = false;
            this.lvServers.ShowItemToolTips = true;
            this.lvServers.Size = new System.Drawing.Size(322, 311);
            this.lvServers.TabIndex = 0;
            this.lvServers.TabStop = false;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
            // 
            // _Name
            // 
            this._Name.Text = "名称";
            this._Name.Width = 83;
            // 
            // _Ip
            // 
            this._Ip.Text = "IP";
            this._Ip.Width = 129;
            // 
            // _Connections
            // 
            this._Connections.Text = "连接数";
            this._Connections.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Connections.Width = 59;
            // 
            // _Rate
            // 
            this._Rate.Text = "倍率";
            this._Rate.Width = 61;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(551, 338);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "调试信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Location = new System.Drawing.Point(5, 5);
            this.txtLog.MaxLength = 327670;
            this.txtLog.MaxLines = 30;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(540, 327);
            this.txtLog.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(555, 361);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(571, 399);
            this.MinimumSize = new System.Drawing.Size(571, 399);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapleStory ServerEmulator Ver079";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvServers;
        private System.Windows.Forms.ColumnHeader _Name;
        private System.Windows.Forms.ColumnHeader _Ip;
        private System.Windows.Forms.ColumnHeader _Connections;
        private System.Windows.Forms.ColumnHeader _Rate;
        private System.Windows.Forms.GroupBox groupBox2;
        private lib.Control.RollingTextBox txtLog;
    }
}

