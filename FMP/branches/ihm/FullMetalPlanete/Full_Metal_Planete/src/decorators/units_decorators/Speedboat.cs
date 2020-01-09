using Metier.Unites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Full_Metal_Planete.src.decorators.units_decorators
{
    public class Speedboat : Unit
    {
        public Speedboat(Unite unite) : base(unite)
        {
        }

        public override double Width => 50;

        public override double Height => 50;

        public override Point GetCenter()
        {
            return new Point((Image.Width / 2), (Image.Height / 2));
        }

        protected override void Unit_OnClick(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
