using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoLibrary
{
    class MovieItem : PictureBox
    {
        Movie movie;

        public MovieItem(Movie movie, MovieManager manager, Form1 form)
        {
            this.movie = movie;
            this.Image = movie.image;
            this.MouseDoubleClick += (s, e) => 
            {
                System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo("cmd", string.Format("/c \"{0}\"", "\"C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe\" \"" + movie.location + "\""));
                System.Diagnostics.Process.Start(ps);
            };
            this.MouseClick += (s, e) =>
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    List<Movie> list = new List<Movie>();
                    list.Add(movie);
                    MovieEdit edit = new MovieEdit(manager, list);
                    edit.ShowDialog();
                    if (edit.changed)
                    {
                        form.RefreshMovieList(true);
                    }
                }
            };

            CustomLabel length = new CustomLabel();
            length.Text = (movie.length / 60).ToString() + ":" + (movie.length % 60).ToString("00");
            length.Size = new System.Drawing.Size(this.Size.Width, 14);
            length.BackColor = Color.Transparent;
            length.ForeColor = Color.White;
            length.OutlineForeColor = Color.Black;
            this.Controls.Add(length);
        }
    }
}
