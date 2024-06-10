using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3.components
{
    internal class Vector2
    {
        internal int X {  get; set; }
        internal int Y { get; set; }
        internal Vector2() { X=0; Y = 0; }  
        internal Vector2(int x,int y) { X=x; Y=y; }
    }
}
