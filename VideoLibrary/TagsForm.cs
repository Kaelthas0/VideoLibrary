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
    partial class TagsForm : Form
    {
        bool all = false;
        public bool changed = false;
        private MovieManager manager;

        public TagsForm(MovieManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            AddTags();
        }

        private void AddTags(string filter = "")
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Selectable<Genre> genre in manager.getAllSearchTags(filter))
            {
                TagItem box = new TagItem(genre);
                box.Text = genre.item.name;
                box.Checked = genre.selected;
                box.AutoCheck = false;
                if (box.genre.notThat)
                {
                    box.ForeColor = Color.Red;
                }
                else
                {
                    box.ForeColor = Color.Black;
                }
                box.MouseClick += (s, e) =>
                {
                    changed = true;
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        box.genre.notThat = !box.genre.notThat;
                        if (box.genre.notThat)
                        {
                            box.ForeColor = Color.Red;
                        }
                        else
                        {
                            box.ForeColor = Color.Black;
                        }

                    }
                    else
                    {
                        box.Checked = !box.Checked;
                        box.genre.selected = box.Checked;
                    }

                };

                flowLayoutPanel1.Controls.Add(box);
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            foreach (Object item in flowLayoutPanel1.Controls)
            {
                if (item is TagItem)
                {
                    TagItem box = (TagItem)item;
                    if (!all)
                    {
                        box.Checked = true;
                        box.genre.selected = true;
                    }
                    else
                    {
                        box.Checked = false;
                        box.genre.selected = false;
                    }
                }
            }
            all = !all;
            changed = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddTags(textBox1.Text);
        }
    }
}
