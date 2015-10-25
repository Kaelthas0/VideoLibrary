namespace VideoLibrary
{
    partial class MovieEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieEdit));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.MovieCountLabel = new System.Windows.Forms.Label();
            this.NewImageButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.NewGenreButton = new System.Windows.Forms.Button();
            this.DeleteGenreButton = new System.Windows.Forms.Button();
            this.AddGenreButton = new System.Windows.Forms.Button();
            this.RemoveGenreButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ChangeGenreButton = new System.Windows.Forms.Button();
            this.ImageTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 217);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // SaveButton
            // 
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Location = new System.Drawing.Point(173, 485);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(1, 299);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(301, 172);
            this.DescriptionTextBox.TabIndex = 2;
            this.DescriptionTextBox.TextChanged += new System.EventHandler(this.DescriptionTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Length:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Location:";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(341, 61);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(0, 13);
            this.LengthLabel.TabIndex = 3;
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(341, 88);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(0, 13);
            this.LocationLabel.TabIndex = 3;
            // 
            // DeleteButton
            // 
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Location = new System.Drawing.Point(254, 485);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Location = new System.Drawing.Point(335, 485);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Movies left:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Id:";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(341, 9);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(0, 13);
            this.IdLabel.TabIndex = 3;
            // 
            // MovieCountLabel
            // 
            this.MovieCountLabel.AutoSize = true;
            this.MovieCountLabel.Location = new System.Drawing.Point(300, 523);
            this.MovieCountLabel.Name = "MovieCountLabel";
            this.MovieCountLabel.Size = new System.Drawing.Size(0, 13);
            this.MovieCountLabel.TabIndex = 5;
            // 
            // NewImageButton
            // 
            this.NewImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewImageButton.Location = new System.Drawing.Point(4, 224);
            this.NewImageButton.Name = "NewImageButton";
            this.NewImageButton.Size = new System.Drawing.Size(75, 23);
            this.NewImageButton.TabIndex = 1;
            this.NewImageButton.Text = "NewImage";
            this.NewImageButton.UseVisualStyleBackColor = true;
            this.NewImageButton.Click += new System.EventHandler(this.NewImageButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(287, 136);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(185, 82);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Genres:";
            // 
            // NewGenreButton
            // 
            this.NewGenreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGenreButton.Location = new System.Drawing.Point(478, 136);
            this.NewGenreButton.Name = "NewGenreButton";
            this.NewGenreButton.Size = new System.Drawing.Size(114, 23);
            this.NewGenreButton.TabIndex = 1;
            this.NewGenreButton.Text = "New Genre";
            this.NewGenreButton.UseVisualStyleBackColor = true;
            this.NewGenreButton.Click += new System.EventHandler(this.NewGenreButton_Click);
            // 
            // DeleteGenreButton
            // 
            this.DeleteGenreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteGenreButton.Location = new System.Drawing.Point(478, 165);
            this.DeleteGenreButton.Name = "DeleteGenreButton";
            this.DeleteGenreButton.Size = new System.Drawing.Size(114, 23);
            this.DeleteGenreButton.TabIndex = 1;
            this.DeleteGenreButton.Text = "Delete Genre";
            this.DeleteGenreButton.UseVisualStyleBackColor = true;
            this.DeleteGenreButton.Click += new System.EventHandler(this.DeleteGenreButton_Click);
            // 
            // AddGenreButton
            // 
            this.AddGenreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddGenreButton.Location = new System.Drawing.Point(287, 224);
            this.AddGenreButton.Name = "AddGenreButton";
            this.AddGenreButton.Size = new System.Drawing.Size(91, 23);
            this.AddGenreButton.TabIndex = 1;
            this.AddGenreButton.Text = "Add Genre";
            this.AddGenreButton.UseVisualStyleBackColor = true;
            this.AddGenreButton.Click += new System.EventHandler(this.AddGenreButton_Click);
            // 
            // RemoveGenreButton
            // 
            this.RemoveGenreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveGenreButton.Location = new System.Drawing.Point(381, 224);
            this.RemoveGenreButton.Name = "RemoveGenreButton";
            this.RemoveGenreButton.Size = new System.Drawing.Size(91, 23);
            this.RemoveGenreButton.TabIndex = 1;
            this.RemoveGenreButton.Text = "Remove Genre";
            this.RemoveGenreButton.UseVisualStyleBackColor = true;
            this.RemoveGenreButton.Click += new System.EventHandler(this.RemoveGenreButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(344, 30);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(248, 20);
            this.NameTextBox.TabIndex = 8;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // ChangeGenreButton
            // 
            this.ChangeGenreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeGenreButton.Location = new System.Drawing.Point(478, 194);
            this.ChangeGenreButton.Name = "ChangeGenreButton";
            this.ChangeGenreButton.Size = new System.Drawing.Size(114, 23);
            this.ChangeGenreButton.TabIndex = 1;
            this.ChangeGenreButton.Text = "Change Genre";
            this.ChangeGenreButton.UseVisualStyleBackColor = true;
            this.ChangeGenreButton.Click += new System.EventHandler(this.ChangeGenreButton_Click);
            // 
            // ImageTrackBar
            // 
            this.ImageTrackBar.Location = new System.Drawing.Point(4, 251);
            this.ImageTrackBar.Name = "ImageTrackBar";
            this.ImageTrackBar.Size = new System.Drawing.Size(274, 45);
            this.ImageTrackBar.TabIndex = 9;
            this.ImageTrackBar.ValueChanged += new System.EventHandler(this.ImageTrackBar_ValueChanged);
            // 
            // MovieEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 544);
            this.Controls.Add(this.ImageTrackBar);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.MovieCountLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.NewImageButton);
            this.Controls.Add(this.RemoveGenreButton);
            this.Controls.Add(this.AddGenreButton);
            this.Controls.Add(this.ChangeGenreButton);
            this.Controls.Add(this.DeleteGenreButton);
            this.Controls.Add(this.NewGenreButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MovieEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MovieEdit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MovieEdit_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label MovieCountLabel;
        private System.Windows.Forms.Button NewImageButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button NewGenreButton;
        private System.Windows.Forms.Button DeleteGenreButton;
        private System.Windows.Forms.Button AddGenreButton;
        private System.Windows.Forms.Button RemoveGenreButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button ChangeGenreButton;
        private System.Windows.Forms.TrackBar ImageTrackBar;
    }
}