using AxAXVLC;
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
    public partial class MoviePlayer : Form
    {
        Queue<Movie> movies;
        int playerCount;
        private int columns, rows;
        private int width, height;
        private AxVLCPlugin2[] player;
        private PlayerController playerController;

        public MoviePlayer(Movie movie)
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.movies = new Queue<Movie>();
            this.movies.Enqueue(movie);
            axVLCPlugin21.Size = this.Size;
            axVLCPlugin21.Visible = true;
            axVLCPlugin21.playlist.add(@"file:///" + movie.location);
            axVLCPlugin21.playlist.play();
            playerController = new PlayerController(axVLCPlugin21);
        }

        public MoviePlayer(HashSet<Movie> movies, int playerCount)
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.movies = new Queue<Movie>(movies);
            this.playerCount = playerCount;
            player = new AxAXVLC.AxVLCPlugin2[playerCount];
            ColumnCalc();
            RowCalc();
            CreatePlayer();
            playerController = new PlayerController(player);
        }

        private void ColumnCalc()
        {
            int m = (int)Math.Sqrt(playerCount);
            if (Math.Sqrt(playerCount) % 1 == 0)
            {
                m--;
            }
            m++;
            columns = m;
            width = this.Size.Width / columns;
        }

        private void RowCalc()
        {
            rows = Convert.ToInt32(Math.Sqrt(playerCount));
            height = this.Size.Height / rows;
        }

        private void CreatePlayer()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoviePlayer));
            for (int i = 0; i < playerCount; i++)
            {
                player[i] = new AxVLCPlugin2();
                ((System.ComponentModel.ISupportInitialize)(player[i])).BeginInit();
                player[i].Enabled = true;
                this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
                player[i].Margin = new System.Windows.Forms.Padding(0);
                player[i].Location = new Point(0, 0);

                player[i].Size = new Size(width, height);
                player[i].PreviewKeyDown += new PreviewKeyDownEventHandler(axVLCPlugin21_PreviewKeyDown);
                player[i].MediaPlayerEndReached += MoviePlayer_MediaPlayerEndReached;
                flowLayoutPanel1.Controls.Add(player[i]);
                ((System.ComponentModel.ISupportInitialize)(player[i])).EndInit();
                player[i].AutoLoop = true;
                player[i].AutoPlay = true;
                player[i].volume = 80;
                if (movies.Count != 0)
                {
                    Movie m = movies.Dequeue();
                    player[i].playlist.add(@"file:///" + m.location);
                    player[i].playlist.play();
                }
                if (movies.Count != 0 && playerCount-i <= movies.Count)
                {
                    Movie m2 = movies.Dequeue();
                    player[i].playlist.add(@"file:///" + m2.location);
                }
            }
        }

        void MoviePlayer_MediaPlayerForward(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void MoviePlayer_MediaPlayerEndReached(object sender, EventArgs e)
        {
            AxVLCPlugin2 p = (AxVLCPlugin2)sender;
            if (movies.Count != 0)
            {
                Movie m = movies.Dequeue();
                p.playlist.add(@"file:///" + m.location);
            }
        }

        private void MoviePlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                playerController.Show();
            }
        }

        private void axVLCPlugin21_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                playerController.Show();
            }
            if (e.KeyCode == Keys.Right)
            {
                AxVLCPlugin2 p = (AxVLCPlugin2)sender;
                if (movies.Count != 0)
                {
                    if (p.playlist.currentItem == p.playlist.items.count - 1)
                    {
                        Movie m = movies.Dequeue();
                        p.playlist.add(@"file:///" + m.location);
                    }
                }
                p.playlist.next();
            }
            if (e.KeyCode == Keys.Left)
            {
                AxVLCPlugin2 p = (AxVLCPlugin2)sender;

                p.playlist.prev();
            }
        }
    }
}
