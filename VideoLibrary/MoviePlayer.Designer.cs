namespace VideoLibrary
{
    partial class MoviePlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoviePlayer));
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.SuspendLayout();
            // 
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(0, 0);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(622, 490);
            this.axVLCPlugin21.TabIndex = 0;
            this.axVLCPlugin21.Visible = false;
            this.axVLCPlugin21.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.axVLCPlugin21_PreviewKeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(622, 490);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.axVLCPlugin21_PreviewKeyDown);
            // 
            // MoviePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 490);
            this.Controls.Add(this.axVLCPlugin21);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MoviePlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MoviePlayer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoviePlayer_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;


    }
}