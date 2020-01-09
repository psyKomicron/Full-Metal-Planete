using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Metal_Planete.src.game.menus
{
    public class Resolution
    {
        private int resX;
        private int resY;

        public Resolution Previous { get; set; }

        public Resolution Next { get; set; }

        public int[] Res { get => new int[] { resX, resY }; }

        public int ResX { get => resX; }

        public int ResY { get => resY; }

        public Resolution(int x, int y)
        {
            resX = x;
            resY = y;
        }

        public override string ToString()
        {
            return resX + "x" + resY;
        }

        public override bool Equals(object obj)
        {
            bool b;
            if (obj is Resolution res)
            {
                if (res.ResX == resX && res.ResY == resY) b = true;
                else b = false;
            }
            else b = false;
            return b;
        }
    }
}
