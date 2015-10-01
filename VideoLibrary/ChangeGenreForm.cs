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
    partial class ChangeGenreForm : Form
    {
        public Genre name;

        public ChangeGenreForm(HashSet<Genre> genres)
        {
            InitializeComponent();
            comboBox1.Items.AddRange(genres.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change this genre?", "Change Genre", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                name = (Genre)comboBox1.SelectedItem;
                name.name = textBox1.Text;
            }
        }
    }
}
