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
    public partial class PlayerController : Form
    {
        public bool playing = true;
        AxAXVLC.AxVLCPlugin2[] player;

        public PlayerController(AxAXVLC.AxVLCPlugin2 player)
        {
            InitializeComponent();
            this.player = new AxAXVLC.AxVLCPlugin2[1];
            this.player[0] = player;
            this.Location = new Point(0, 0);
        }

        public PlayerController(AxAXVLC.AxVLCPlugin2[] player)
        {
            InitializeComponent();
            this.player = player;
            this.Location = new Point(0, 0);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            foreach (AxAXVLC.AxVLCPlugin2 p in player)
            {
                p.volume = trackBar1.Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                foreach (AxAXVLC.AxVLCPlugin2 p in player)
                {
                    p.playlist.pause();
                }
                playing = false;
                button1.Text = "Play";
            }
            else
            {
                foreach (AxAXVLC.AxVLCPlugin2 p in player)
                {
                    p.playlist.play();
                }
                playing = true;
                button1.Text = "Pause";
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }
    }
}
