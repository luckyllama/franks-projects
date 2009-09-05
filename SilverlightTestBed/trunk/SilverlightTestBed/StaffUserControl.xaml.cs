using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace SilverlightTestBed {
    public partial class StaffUserControl : UserControl {
        private static int TOP_BOTTOM_PADDING = 10;
        private static int NUMBER_OF_LINES = 11;
        private int lineHeight;

        #region Constructor & Initialization

        public StaffUserControl() {
            InitializeComponent(); 
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e) {
            InitializeUserControl();
        }

        private void InitializeUserControl() {
            lineHeight = (int)((this.Height - (TOP_BOTTOM_PADDING * 2)) / NUMBER_OF_LINES);
            setupStaffLines();

            StaffRectangle.Width = this.Width;
            StaffRectangle.Height = this.Height;
        }

        private void setupStaffLines() {
            setupLine(ref Line_Top3Above, Colors.White, 1);
            setupLine(ref Line_Top2Above, Colors.White, 2);
            setupLine(ref Line_Top1Above, Colors.White, 3);
            setupLine(ref Line_Top, Colors.Black, 4);
            setupLine(ref Line_TopMiddle, Colors.Black, 5);
            setupLine(ref Line_Middle, Colors.Black, 6);
            setupLine(ref Line_BottomMiddle, Colors.Black, 7);
            setupLine(ref Line_Bottom, Colors.Black, 8);
            setupLine(ref Line_Bottom1Below, Colors.White, 9);
            setupLine(ref Line_Bottom2Below, Colors.White, 10);
            setupLine(ref Line_Bottom3Below, Colors.White, 11);
        }

        private void setupLine(ref Line line, Color color, int linePosition) {
            line.Cursor = Cursors.None;
            line.Stroke = new SolidColorBrush(color);
            line.StrokeThickness = 2;
            line.X1 = 0;
            line.X2 = this.Width;
            int lineY = lineHeight * linePosition;
            line.Y1 = lineY;
            line.Y2 = lineY;
        }

        #endregion Constructor & Initialization

        private void LayoutRoot_MouseMove(object sender, MouseEventArgs e) {
            BitmapImage image = new BitmapImage(new Uri("whole-note.png", UriKind.Relative));
            Note.Source = image;
            Note.Height = lineHeight;
            Point position = e.GetPosition(null);
            Note.SetValue(Canvas.LeftProperty, position.X);
            Note.SetValue(Canvas.TopProperty, getSnapToPositionY(position.Y));
        }

        private double getSnapToPositionY(double y) {
            return ((int) y / (lineHeight / 2)) * (lineHeight / 2);
        }

        private void StaffRectangle_MouseLeave(object sender, MouseEventArgs e) {

        }
    }
}
