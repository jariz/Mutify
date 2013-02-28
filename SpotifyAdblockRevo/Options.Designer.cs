namespace Mutify
{
    partial class Options
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.downloadCoverArt = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.blockAds = new System.Windows.Forms.CheckBox();
            this.messageTrack = new System.Windows.Forms.CheckBox();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.messageLoad = new System.Windows.Forms.CheckBox();
            this.startMinimized = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadCoverArt
            // 
            this.downloadCoverArt.AutoSize = true;
            this.downloadCoverArt.Checked = true;
            this.downloadCoverArt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downloadCoverArt.Location = new System.Drawing.Point(6, 19);
            this.downloadCoverArt.Name = "downloadCoverArt";
            this.downloadCoverArt.Size = new System.Drawing.Size(119, 17);
            this.downloadCoverArt.TabIndex = 0;
            this.downloadCoverArt.Text = "Download cover art";
            this.downloadCoverArt.UseVisualStyleBackColor = true;
            this.downloadCoverArt.CheckedChanged += new System.EventHandler(this.messageLoad_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.startMinimized);
            this.groupBox1.Controls.Add(this.messageLoad);
            this.groupBox1.Controls.Add(this.messageTrack);
            this.groupBox1.Controls.Add(this.blockAds);
            this.groupBox1.Controls.Add(this.downloadCoverArt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 386);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(465, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(93, 17);
            this.toolStripStatusLabel1.Text = "Program status: ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // blockAds
            // 
            this.blockAds.AutoSize = true;
            this.blockAds.Checked = true;
            this.blockAds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blockAds.Location = new System.Drawing.Point(6, 42);
            this.blockAds.Name = "blockAds";
            this.blockAds.Size = new System.Drawing.Size(73, 17);
            this.blockAds.TabIndex = 1;
            this.blockAds.Text = "Block ads";
            this.blockAds.UseVisualStyleBackColor = true;
            this.blockAds.CheckedChanged += new System.EventHandler(this.messageLoad_CheckedChanged);
            // 
            // messageTrack
            // 
            this.messageTrack.AutoSize = true;
            this.messageTrack.Location = new System.Drawing.Point(6, 65);
            this.messageTrack.Name = "messageTrack";
            this.messageTrack.Size = new System.Drawing.Size(198, 17);
            this.messageTrack.TabIndex = 2;
            this.messageTrack.Text = "Show message when track changes";
            this.messageTrack.UseVisualStyleBackColor = true;
            this.messageTrack.CheckedChanged += new System.EventHandler(this.messageLoad_CheckedChanged);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // messageLoad
            // 
            this.messageLoad.AutoSize = true;
            this.messageLoad.Checked = true;
            this.messageLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.messageLoad.Location = new System.Drawing.Point(6, 88);
            this.messageLoad.Name = "messageLoad";
            this.messageLoad.Size = new System.Drawing.Size(203, 17);
            this.messageLoad.TabIndex = 3;
            this.messageLoad.Text = "Show message when Mutify is loaded";
            this.messageLoad.UseVisualStyleBackColor = true;
            this.messageLoad.CheckedChanged += new System.EventHandler(this.messageLoad_CheckedChanged);
            // 
            // startMinimized
            // 
            this.startMinimized.AutoSize = true;
            this.startMinimized.Checked = true;
            this.startMinimized.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startMinimized.Location = new System.Drawing.Point(6, 111);
            this.startMinimized.Name = "startMinimized";
            this.startMinimized.Size = new System.Drawing.Size(96, 17);
            this.startMinimized.TabIndex = 4;
            this.startMinimized.Text = "Start minimized";
            this.startMinimized.UseVisualStyleBackColor = true;
            this.startMinimized.CheckedChanged += new System.EventHandler(this.messageLoad_CheckedChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 425);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox downloadCoverArt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox messageTrack;
        private System.Windows.Forms.CheckBox blockAds;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.CheckBox messageLoad;
        private System.Windows.Forms.CheckBox startMinimized;
    }
}