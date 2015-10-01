using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoLibrary
{
    class TagItem : CheckBox
    {
        public Selectable<Genre> genre;

        public TagItem(Selectable<Genre> genre)
        {
            this.genre = genre;
        }
    }
}
