using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary
{
    public class Selectable<T>
    {
        public T item;
        public bool selected = false;
        public bool notThat = false;

        public Selectable(T item)
        {
            this.item = item;
        }
    }
}
