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
    public partial class Form1 : Form
    {
        MovieManager manager = new MovieManager();
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            RefreshMovieList();
        }

        private void addNewMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<Movie> list = manager.GetAllNewMovies(dialog.SelectedPath);
                if (list.Count == 0)
                {
                    MessageBox.Show("No new Movies found");
                }
                else
                {
                    MovieEdit edit = new MovieEdit(manager, list);
                    edit.ShowDialog();
                    RefreshMovieList();
                }
            }
            
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshMovieList();
        }

        public void RefreshMovieList()
        {
            flowLayoutPanel1.Controls.Clear();
            HashSet<Movie> list = manager.getMoviesWithFilter(searchTextBox.Text);

            foreach (Movie movie in list)
            {
                MovieItem item = new MovieItem(movie, manager, this);
                item.Size = new Size(200, 150);
                item.SizeMode = PictureBoxSizeMode.StretchImage;
                flowLayoutPanel1.Controls.Add(item);
            }

            TotalVideoCountLabel.Text = manager.getMovies().Count.ToString();
            CurrentlyDisplayedLabel.Text = flowLayoutPanel1.Controls.Count.ToString();
        }

        public void RefreshMovieList(bool scroll)
        {
            int value = flowLayoutPanel1.VerticalScroll.Value;
            flowLayoutPanel1.Controls.Clear();
            HashSet<Movie> list = manager.getMoviesWithFilter(searchTextBox.Text);

            foreach (Movie movie in list)
            {
                MovieItem item = new MovieItem(movie, manager, this);
                item.Size = new Size(200, 150);
                item.SizeMode = PictureBoxSizeMode.StretchImage;
                flowLayoutPanel1.Controls.Add(item);
            }
            flowLayoutPanel1.VerticalScroll.Value = value;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            using (TagsForm form = new TagsForm(manager))
            {
                form.ShowDialog();
                RefreshMovieList();
            }
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            Movie[] rMovies = manager.getMoviesWithFilter(searchTextBox.Text).ToArray<Movie>();
            System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo("cmd", string.Format("/c \"{0}\"", "\"C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe\" \"" + rMovies[rnd.Next(0, rMovies.Length)].location + "\""));
            System.Diagnostics.Process.Start(ps);
        }

        private void OpenAllButton_Click(object sender, EventArgs e)
        {
            Movie[] rMovies = manager.getMoviesWithFilter(searchTextBox.Text).ToArray<Movie>();
            string allmovies = "";
            foreach (Movie movie in rMovies)
            {
                allmovies += "\"" + movie.location + "\" ";
            }
            System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo("cmd", string.Format("/c \"{0}\"", "\"C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe\" " + allmovies + ""));
            System.Diagnostics.Process.Start(ps);
        }

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            flowLayoutPanel1.Focus();
        }
    }
}
