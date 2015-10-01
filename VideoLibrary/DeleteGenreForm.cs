using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoLibrary
{
    partial class DeleteGenreForm : Form
    {
        public Genre name;
        private string text;

        public DeleteGenreForm(HashSet<Genre> genres, string text)
        {
            InitializeComponent();
            comboBox1.Items.AddRange(genres.ToArray());
            this.text = text;
            if (text == "1")
            {
                this.Text = "Delete Genre";
            }
            else if (text == "2")
            {
                this.Text = "Add Genre";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t="", caption="";
            if (text == "1")
            {
                t = "Are you sure you want to delete this genre?";
                caption = "Delete";
                if (MessageBox.Show(t, caption, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    name = (Genre)comboBox1.SelectedItem;
                }
            }
            else if (text == "2")
            {
                name = (Genre)comboBox1.SelectedItem;
            }
            
        }
    }
}
