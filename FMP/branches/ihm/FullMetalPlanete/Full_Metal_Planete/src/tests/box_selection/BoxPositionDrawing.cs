﻿using Full_Metal_Planete.src.decorators;
using Full_Metal_Planete.src.game.game_window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Full_Metal_Planete.src.tests.box_selection
{
    public class BoxPositionDrawing
    {
        private MapHMI mapIHM;

        private Canvas canvas;

        public BoxPositionDrawing(MapHMI map, Canvas canvas)
        {
            mapIHM = map;
            this.canvas = canvas;
        }

        public void DrawPoints()
        {
            Polyline polyline = new Polyline();
            foreach (Box boxIHM in mapIHM.BoxesIHM)
            {
                polyline.Points.Add(boxIHM.Position);
            }
            canvas.Children.Add(polyline);
            Canvas.SetZIndex(polyline, FullMetalPlaneteScreen.MAXZINDEX + 1);
        }
    }
}
