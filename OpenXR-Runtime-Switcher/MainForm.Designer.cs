
namespace OpenXR_Runtime_Switcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanelPresets = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelCustoms = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddCustom = new System.Windows.Forms.Button();
            this.btnRemoveCustom = new System.Windows.Forms.Button();
            this.panelSplash = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerSplash = new System.Windows.Forms.Timer(this.components);
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelSplash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPresets
            // 
            this.flowLayoutPanelPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelPresets.AutoScroll = true;
            this.flowLayoutPanelPresets.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.flowLayoutPanelPresets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelPresets.Location = new System.Drawing.Point(2, 27);
            this.flowLayoutPanelPresets.Name = "flowLayoutPanelPresets";
            this.flowLayoutPanelPresets.Size = new System.Drawing.Size(375, 427);
            this.flowLayoutPanelPresets.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(763, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WebsiteToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.MouseLeave += new System.EventHandler(this.ToolStripMenuItem_MouseLeave);
            this.menuToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ToolStripMenuItem_MouseMove);
            // 
            // WebsiteToolStripMenuItem
            // 
            this.WebsiteToolStripMenuItem.Name = "WebsiteToolStripMenuItem";
            this.WebsiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.WebsiteToolStripMenuItem.Text = "Website";
            this.WebsiteToolStripMenuItem.Click += new System.EventHandler(this.WebsiteStripMenuItem_Click);
            this.WebsiteToolStripMenuItem.MouseLeave += new System.EventHandler(this.ToolStripMenuItem_MouseLeave);
            this.WebsiteToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ToolStripMenuItem_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // flowLayoutPanelCustoms
            // 
            this.flowLayoutPanelCustoms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelCustoms.AutoScroll = true;
            this.flowLayoutPanelCustoms.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.flowLayoutPanelCustoms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelCustoms.Location = new System.Drawing.Point(383, 133);
            this.flowLayoutPanelCustoms.Name = "flowLayoutPanelCustoms";
            this.flowLayoutPanelCustoms.Size = new System.Drawing.Size(375, 321);
            this.flowLayoutPanelCustoms.TabIndex = 7;
            this.flowLayoutPanelCustoms.Click += new System.EventHandler(this.MainForm_Click);
            // 
            // btnRefreshAll
            // 
            this.btnRefreshAll.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRefreshAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshAll.Location = new System.Drawing.Point(383, 27);
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshAll.Size = new System.Drawing.Size(375, 34);
            this.btnRefreshAll.TabIndex = 51;
            this.btnRefreshAll.Text = "REFRESH ALL";
            this.btnRefreshAll.UseVisualStyleBackColor = false;
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(383, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 33);
            this.label2.TabIndex = 52;
            this.label2.Text = "Custom Runtimes";
            this.label2.Click += new System.EventHandler(this.MainForm_Click);
            // 
            // btnAddCustom
            // 
            this.btnAddCustom.BackColor = System.Drawing.Color.Green;
            this.btnAddCustom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustom.Location = new System.Drawing.Point(383, 104);
            this.btnAddCustom.Name = "btnAddCustom";
            this.btnAddCustom.Size = new System.Drawing.Size(75, 23);
            this.btnAddCustom.TabIndex = 53;
            this.btnAddCustom.Text = "Add";
            this.btnAddCustom.UseVisualStyleBackColor = false;
            this.btnAddCustom.Click += new System.EventHandler(this.btnAddCustom_Click);
            // 
            // btnRemoveCustom
            // 
            this.btnRemoveCustom.BackColor = System.Drawing.Color.DarkRed;
            this.btnRemoveCustom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCustom.Location = new System.Drawing.Point(464, 104);
            this.btnRemoveCustom.Name = "btnRemoveCustom";
            this.btnRemoveCustom.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCustom.TabIndex = 54;
            this.btnRemoveCustom.Text = "Remove";
            this.btnRemoveCustom.UseVisualStyleBackColor = false;
            this.btnRemoveCustom.Click += new System.EventHandler(this.btnRemoveCustom_Click);
            // 
            // panelSplash
            // 
            this.panelSplash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSplash.Controls.Add(this.pictureBox1);
            this.panelSplash.Location = new System.Drawing.Point(0, 0);
            this.panelSplash.Name = "panelSplash";
            this.panelSplash.Size = new System.Drawing.Size(763, 466);
            this.panelSplash.TabIndex = 56;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::OpenXR_Runtime_Switcher.Properties.Resources.AppLogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(739, 442);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timerSplash
            // 
            this.timerSplash.Enabled = true;
            this.timerSplash.Interval = 1000;
            this.timerSplash.Tick += new System.EventHandler(this.timerSplash_Tick);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for Update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            this.checkForUpdateToolStripMenuItem.MouseLeave += new System.EventHandler(this.ToolStripMenuItem_MouseLeave);
            this.checkForUpdateToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ToolStripMenuItem_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(763, 466);
            this.Controls.Add(this.panelSplash);
            this.Controls.Add(this.btnRemoveCustom);
            this.Controls.Add(this.btnAddCustom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRefreshAll);
            this.Controls.Add(this.flowLayoutPanelCustoms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanelPresets);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(779, 99999999);
            this.MinimumSize = new System.Drawing.Size(779, 295);
            this.Name = "MainForm";
            this.Text = "OpenXR Runtime-Switcher";
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelSplash.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPresets;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Button btnRefreshAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddCustom;
        private System.Windows.Forms.ToolStripMenuItem WebsiteToolStripMenuItem;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnRemoveCustom;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCustoms;
        private System.Windows.Forms.Panel panelSplash;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerSplash;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
    }
}

