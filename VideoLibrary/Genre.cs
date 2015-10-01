using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary
{
    class Genre
    {
        public int id;
        public string name;

        public Genre(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Genre)
            {
                return ((Genre)obj).name == name;
            }
            return false;
        }
    }
}
