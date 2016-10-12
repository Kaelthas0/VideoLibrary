using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoLibrary
{
    partial class MovieEdit : Form
    {
        private MovieManager manager;
        private Movie currentMovie;
        private Queue<Movie> queue;
        private Random rnd = new Random();
        private Form1 form;
        private MovieItem movieItem;
        public bool changed = false;
        public bool changedImage = false;
        public bool newMovie = true;

        public MovieEdit(MovieManager manager, List<Movie> movies, Form1 form)
        {
            InitializeComponent();
            this.manager = manager;
            queue = new Queue<Movie>(movies);
            DisplayNewMovie();
            this.form = form;
        }

        public MovieEdit(MovieManager manager, List<Movie> movies, Form1 form, MovieItem movieItem) : this(manager, movies, form)
        {
            this.movieItem = movieItem;
        }

        private void DisplayNewMovie()
        {
            if (queue.Count != 0)
            {
                currentMovie = queue.Dequeue();
                RefreshForm();
                changedImage = false;
            }
            else
            {
                this.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this movie?", "Save", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (changedImage)
                {
                    MemoryStream stream = new MemoryStream();

                    var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                    ffMpeg.GetVideoThumbnail(currentMovie.location, stream, ImageTrackBar.Value);
                    currentMovie.image = new Bitmap(stream);
                }
                manager.InsertOrUpdateMovie(currentMovie);
                if (newMovie)
                {
                    manager.getMovies().Add(currentMovie);
                    form.AddNewMovie(currentMovie);
                }
                changed = true;
            }
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            currentMovie.description = DescriptionTextBox.Text;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to delete this movie?", "Delete", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                manager.DeleteMovie(currentMovie);
                form.RemoveMovie(movieItem);
                DisplayNewMovie();
                changed = true;
            }
            
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            DisplayNewMovie();
        }

        private void NewGenreButton_Click(object sender, EventArgs e)
        {
            using (NewGenreForm form = new NewGenreForm())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    manager.InsertOrUpdateGenre(new Genre(0, form.name));
                    RefreshForm();
                }
            }
        }

        private void RefreshForm()
        {
            IdLabel.Text = currentMovie.id.ToString();
            NameTextBox.Text = currentMovie.name;
            LengthLabel.Text = (currentMovie.length / 60).ToString() + ":" + (currentMovie.length % 60).ToString("00");
            LocationLabel.Text = currentMovie.location;
            DescriptionTextBox.Text = currentMovie.description;
            pictureBox1.Image = currentMovie.image;
            MovieCountLabel.Text = queue.Count.ToString();

            flowLayoutPanel1.Controls.Clear();
            foreach (Genre genre in currentMovie.genres)
            {
                Label label = new Label();
                label.Size = new Size(flowLayoutPanel1.Size.Width-10, 21);
                label.Text = genre.name;

                flowLayoutPanel1.Controls.Add(label);
            }

            ImageTrackBar.Maximum = currentMovie.length;
            MostUsedGenrelistBox.Items.Clear();
            List<KeyValuePair<string, int>> l = new List<KeyValuePair<string, int>>();
            l = manager.getMostUsedGenres();
            int i = 0;
            foreach (KeyValuePair<string, int> item in l)
            {
                bool contains = false;
                foreach (Genre g in currentMovie.genres)
                {
                    if (g.name == item.Key)
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    MostUsedGenrelistBox.Items.Add(manager.getGenres().Where(ii => ii.name == item.Key).First());
                    i++;
                }
                if (i == 13) break;
            }
        }

        private void DeleteGenreButton_Click(object sender, EventArgs e)
        {
            using (DeleteGenreForm form = new DeleteGenreForm(manager.getGenres(), "1"))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    manager.DeleteGenre(form.name);

                    RefreshForm();
                }
            }
        }

        private void AddGenreButton_Click(object sender, EventArgs e)
        {
            using (DeleteGenreForm form = new DeleteGenreForm(manager.getGenres(), "2"))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentMovie.genres.Add(form.name);
                    RefreshForm();
                }
            }
        }

        private void RemoveGenreButton_Click(object sender, EventArgs e)
        {
            using (DeleteGenreForm form = new DeleteGenreForm(currentMovie.genres, "1"))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentMovie.genres.Remove(form.name);

                    RefreshForm();
                }
            }
        }

        private void NewImageButton_Click(object sender, EventArgs e)
        {
            ImageTrackBar.Value = rnd.Next(1, currentMovie.length);
            changedImage = true;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            currentMovie.name = NameTextBox.Text;
        }

        private void ChangeGenreButton_Click(object sender, EventArgs e)
        {
            using (ChangeGenreForm form = new ChangeGenreForm(manager.getGenres()))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    manager.InsertOrUpdateGenre(form.name);

                    RefreshForm();
                }
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo("cmd", string.Format("/c \"{0}\"", "\"C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe\" \"" + currentMovie.location + "\""));
            //System.Diagnostics.Process.Start(ps);
            if (Form.ModifierKeys == Keys.Control)
            {
                System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo("cmd", string.Format("/c \"{0}\"", "\"C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe\" \"" + currentMovie.location + "\""));
                System.Diagnostics.Process.Start(ps);
            }
            else
            {

                new MoviePlayer(currentMovie).Show();
            }
        }

        private void ImageTrackBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                MemoryStream stream = new MemoryStream();

                var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                ffMpeg.GetVideoThumbnail(currentMovie.location, stream, ImageTrackBar.Value);
                currentMovie.image.Dispose();
                currentMovie.image = new Bitmap(stream);
                RefreshForm();
                stream.Close();
                changedImage = true;
            }
            catch { }
        }

        private void MovieEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            //manager.UpdateMovieList();
        }

        private void MostUsedGenrelistBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            currentMovie.genres.Add((Genre)MostUsedGenrelistBox.SelectedItem);
            RefreshForm();
        }
    }
}
