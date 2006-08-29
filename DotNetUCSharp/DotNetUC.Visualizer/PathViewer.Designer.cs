namespace DotNetUC.Visualizer
{
    partial class PathViewer
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
            this.pcbPreview = new System.Windows.Forms.PictureBox();
            this.txtPoints = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbPreview
            // 
            this.pcbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbPreview.Location = new System.Drawing.Point(155, 12);
            this.pcbPreview.Name = "pcbPreview";
            this.pcbPreview.Size = new System.Drawing.Size(433, 427);
            this.pcbPreview.TabIndex = 0;
            this.pcbPreview.TabStop = false;
            this.pcbPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pcbPreview_Paint);
            // 
            // txtPoints
            // 
            this.txtPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPoints.Location = new System.Drawing.Point(12, 12);
            this.txtPoints.Multiline = true;
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(137, 427);
            this.txtPoints.TabIndex = 1;
            // 
            // PathViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 451);
            this.Controls.Add(this.txtPoints);
            this.Controls.Add(this.pcbPreview);
            this.Name = "PathViewer";
            this.Text = "PathOverview";
            ((System.ComponentModel.ISupportInitialize)(this.pcbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbPreview;
        private System.Windows.Forms.TextBox txtPoints;
    }
}