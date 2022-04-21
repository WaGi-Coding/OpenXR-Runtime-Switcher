
namespace OpenXR_Runtime_Switcher
{
    partial class RuntimeEntryControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblRuntimeName = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.btnCopyPath = new System.Windows.Forms.Button();
            this.toolTipUC = new System.Windows.Forms.ToolTip(this.components);
            this.btnHandle = new System.Windows.Forms.Button();
            this.pictureBox_RuntimeLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RuntimeLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRuntimeName
            // 
            this.lblRuntimeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuntimeName.Location = new System.Drawing.Point(103, 3);
            this.lblRuntimeName.Name = "lblRuntimeName";
            this.lblRuntimeName.Size = new System.Drawing.Size(244, 38);
            this.lblRuntimeName.TabIndex = 9999;
            this.lblRuntimeName.Text = "No Runtime Name Defined for this Entry";
            this.lblRuntimeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRuntimeName.Click += new System.EventHandler(this.RuntimeEntryControl_Click);
            this.lblRuntimeName.MouseLeave += new System.EventHandler(this.RuntimeEntryControl_MouseLeave);
            this.lblRuntimeName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RuntimeEntryControl_MouseMove);
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(132, 77);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(161, 20);
            this.tbPath.TabIndex = 2;
            this.tbPath.DoubleClick += new System.EventHandler(this.tbPath_DoubleClick);
            this.tbPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPath_KeyDown);
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(100, 75);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 23);
            this.labelPath.TabIndex = 9999;
            this.labelPath.Text = "Path:";
            this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyPath.Enabled = false;
            this.btnCopyPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyPath.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyPath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyPath.Location = new System.Drawing.Point(299, 77);
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.Size = new System.Drawing.Size(48, 20);
            this.btnCopyPath.TabIndex = 3;
            this.btnCopyPath.Text = "COPY";
            this.btnCopyPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTipUC.SetToolTip(this.btnCopyPath, "Copy Path to Clipboard");
            this.btnCopyPath.UseMnemonic = false;
            this.btnCopyPath.UseVisualStyleBackColor = true;
            this.btnCopyPath.Click += new System.EventHandler(this.btnCopyPath_Click);
            // 
            // btnHandle
            // 
            this.btnHandle.BackColor = System.Drawing.Color.DarkRed;
            this.btnHandle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHandle.Enabled = false;
            this.btnHandle.FlatAppearance.BorderSize = 2;
            this.btnHandle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHandle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHandle.Location = new System.Drawing.Point(103, 44);
            this.btnHandle.Name = "btnHandle";
            this.btnHandle.Size = new System.Drawing.Size(244, 27);
            this.btnHandle.TabIndex = 1;
            this.btnHandle.Text = "Error in determining the Status";
            this.btnHandle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHandle.UseVisualStyleBackColor = false;
            this.btnHandle.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // pictureBox_RuntimeLogo
            // 
            this.pictureBox_RuntimeLogo.Image = global::OpenXR_Runtime_Switcher.Properties.Resources.Logo_NoLogo;
            this.pictureBox_RuntimeLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_RuntimeLogo.Name = "pictureBox_RuntimeLogo";
            this.pictureBox_RuntimeLogo.Size = new System.Drawing.Size(94, 94);
            this.pictureBox_RuntimeLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_RuntimeLogo.TabIndex = 0;
            this.pictureBox_RuntimeLogo.TabStop = false;
            this.pictureBox_RuntimeLogo.Click += new System.EventHandler(this.RuntimeEntryControl_Click);
            this.pictureBox_RuntimeLogo.MouseLeave += new System.EventHandler(this.RuntimeEntryControl_MouseLeave);
            this.pictureBox_RuntimeLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RuntimeEntryControl_MouseMove);
            // 
            // RuntimeEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.btnHandle);
            this.Controls.Add(this.btnCopyPath);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.lblRuntimeName);
            this.Controls.Add(this.pictureBox_RuntimeLogo);
            this.Name = "RuntimeEntryControl";
            this.Size = new System.Drawing.Size(350, 100);
            this.Click += new System.EventHandler(this.RuntimeEntryControl_Click);
            this.MouseLeave += new System.EventHandler(this.RuntimeEntryControl_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RuntimeEntryControl_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RuntimeLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_RuntimeLogo;
        private System.Windows.Forms.Label lblRuntimeName;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button btnCopyPath;
        private System.Windows.Forms.ToolTip toolTipUC;
        private System.Windows.Forms.Button btnHandle;
    }
}
