using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace ConquistadorGame.Model {

    public class RoundRectangleCreater {

        public static void DrawFilledRoundRectangle(Graphics g, Brush brush, float x, float y, float width, float height, float radius) {
            GraphicsPath path = getRoundRectanglePath(x, y, width, height, radius);
            g.FillPath(brush, path);
            path.Dispose();
        }

        public static void DrawOutlinedRoundRectangle(Graphics g, Pen pen, float x, float y, float width, float height, float radius) {
            GraphicsPath path = getRoundRectanglePath(x, y, width, height, radius);
            g.DrawPath(pen, path);
            path.Dispose();
        }

        private static GraphicsPath getRoundRectanglePath(float x, float y, float width, float height, float radius) {
            GraphicsPath path = new GraphicsPath();

            path.AddLine(x + radius, y, x + width - (radius * 2), y);
            path.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            path.AddLine(x + width, y + radius, x + width, y + height - (radius * 2));
            path.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            path.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            path.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            path.AddLine(x, y + height - (radius * 2), x, y + radius);
            path.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            path.CloseFigure();

            return path;
        }
    }

}
