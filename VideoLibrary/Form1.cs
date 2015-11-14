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
                    MovieEdit edit = new MovieEdit(manager, list, this);
                    edit.ShowDialog();
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
                AddNewMovie(movie);
            }

            TotalVideoCountLabel.Text = manager.getMovies().Count.ToString();
            CurrentlyDisplayedLabel.Text = flowLayoutPanel1.Controls.Count.ToString();
            
        }

        public void RefreshMovieList(bool scroll)
        {
            int value = flowLayoutPanel1.VerticalScroll.Value;
            RefreshMovieList();
            flowLayoutPanel1.VerticalScroll.Value = value;
        }

        public void AddNewMovie(Movie movie)
        {
            MovieItem item = new MovieItem(movie, manager, this);
            item.Size = new Size(200, 150);
            item.SizeMode = PictureBoxSizeMode.StretchImage;
            flowLayoutPanel1.Controls.Add(item);
        }

        public void RemoveMovie(MovieItem item)
        {
            flowLayoutPanel1.Controls.Remove(item);
        }


        private void FilterButton_Click(object sender, EventArgs e)
        {
            using (TagsForm form = new TagsForm(manager))
            {
                form.ShowDialog();
                if (form.changed)
                {
                    RefreshMovieList();
                }
            }
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            Movie[] rMovies = manager.getMoviesWithFilter(searchTextBox.Text).ToArray<Movie>();
            //System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo("cmd", string.Format("/c \"{0}\"", "\"C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe\" \"" + rMovies[rnd.Next(0, rMovies.Length)].location + "\""));
            //System.Diagnostics.Process.Start(ps);
            new MoviePlayer(rMovies[rnd.Next(0, rMovies.Length)]).Show();
        }

        private void OpenAllButton_Click(object sender, EventArgs e)
        {
            Movie[] m = manager.getMoviesWithFilter(searchTextBox.Text).ToArray<Movie>();
            UtilsScript.ShuffleArray<Movie>(m);
            new MoviePlayer(new HashSet<Movie>(m), Convert.ToInt32(textBox1.Text)).Show();
        }

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            flowLayoutPanel1.Focus();
        }
    }

    public static class UtilsScript {

        private static Random rnd = new Random();

        public static void ShuffleArray<T>(T[] arr)
        {
            for (var i = arr.Length - 1; i > 0; i--)
            {
                var r = rnd.Next(0, i);
                var tmp = arr[i];
                arr[i] = arr[r];
                arr[r] = tmp;
            }
        }
    }

}
