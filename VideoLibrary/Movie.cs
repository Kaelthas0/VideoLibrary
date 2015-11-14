using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary
{
    public class Movie
    {
        public int id;
        public string name;
        public int length;
        public string location;
        public string description;
        public Bitmap image;
        public HashSet<Genre> genres = new HashSet<Genre>();

        public Movie(int id, string name, int length, string location, string description, Bitmap image)
        {
            this.id = id;
            this.name = name;
            this.length = length;
            this.location = location;
            this.description = description;
            this.image = image;
        }
    }
}
