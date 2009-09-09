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
using SilverlightTestBed.Clef;

namespace SilverlightTestBed {
    public partial class StaffUserControl : UserControl {

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

            if (Clef != ClefType.None) {
                setupClef();
            }

            StaffRectangle.Width = this.Width;
            StaffRectangle.Height = this.Height;
        }

        private void setupStaffLines() {
            setupLine(ref Line_Top3Above, Colors.Black, 1);
            setupLine(ref Line_Top2Above, Colors.Black, 2);
            setupLine(ref Line_Top1Above, Colors.Black, 3);
            setupLine(ref Line_Top, Colors.Black, 4);
            setupLine(ref Line_TopMiddle, Colors.Black, 5);
            setupLine(ref Line_Middle, Colors.Black, 6);
            setupLine(ref Line_BottomMiddle, Colors.Black, 7);
            setupLine(ref Line_Bottom, Colors.Black, 8);
            setupLine(ref Line_Bottom1Below, Colors.Black, 9);
            setupLine(ref Line_Bottom2Below, Colors.Black, 10);
            setupLine(ref Line_Bottom3Below, Colors.Black, 11);
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

        private void setupClef() {
            switch (Clef) {
                case ClefType.Treble :
                    clef = new TrebleClef();
                    break;
                case ClefType.Bass :
                    clef = new BassClef();
                    break;
                default :
                    clef = null;
                    break;
            }

            if (clef != null) {
                Image clefImage = clef.GetClefImage(lineHeight);
                double topProperty = Line_Top.Y1 + clef.GetClefTopPosition(lineHeight);
                clefImage.SetValue(Canvas.TopProperty, topProperty);
                clefImage.SetValue(Canvas.LeftProperty, LEFT_PADDING);
                LayoutRoot.Children.Add(clefImage);
            }
        }

        #endregion Constructor & Initialization

        #region Events 

        private void LayoutRoot_MouseMove(object sender, MouseEventArgs e) {
            BitmapImage image = new BitmapImage(new Uri("Content/Images/Notes/whole-note.png", UriKind.Relative));
            Note.Source = image;
            Note.Height = lineHeight;
            Point position = e.GetPosition(null);
            double topProperty = getSnapToPositionY(position.Y);
            double leftProperty = position.X;
            Note.SetValue(Canvas.LeftProperty, leftProperty);
            Note.SetValue(Canvas.TopProperty, topProperty);

            showLedgerLines(topProperty, leftProperty);
        }

        private double getSnapToPositionY(double y) {
            return ((int) y / (lineHeight / 2)) * (lineHeight / 2);
        }

        private void showLedgerLines(double topPoint, double leftPoint) {
            double bottomPoint = topPoint + lineHeight;
            if (shouldShowLedgerLine(Line_Top1Above, topPoint, bottomPoint)) {
                showLedgerLine(ref Line_Top1Above, leftPoint);
            } else {
                Line_Top1Above.Visibility = Visibility.Collapsed;
            }

            if (shouldShowLedgerLine(Line_Top2Above, topPoint, bottomPoint)) {
                showLedgerLine(ref Line_Top2Above, leftPoint);
            } else {
                Line_Top2Above.Visibility = Visibility.Collapsed;
            }

            if (shouldShowLedgerLine(Line_Top3Above, topPoint, bottomPoint)) {
                showLedgerLine(ref Line_Top3Above, leftPoint);
            } else {
                Line_Top3Above.Visibility = Visibility.Collapsed;
            }

            if (shouldShowLedgerLine(Line_Bottom1Below, topPoint, bottomPoint)) {
                showLedgerLine(ref Line_Bottom1Below, leftPoint);
            } else {
                Line_Bottom1Below.Visibility = Visibility.Collapsed;
            }

            if (shouldShowLedgerLine(Line_Bottom2Below, topPoint, bottomPoint)) {
                showLedgerLine(ref Line_Bottom2Below, leftPoint);
            } else {
                Line_Bottom2Below.Visibility = Visibility.Collapsed;
            }

            if (shouldShowLedgerLine(Line_Bottom3Below, topPoint, bottomPoint)) {
                showLedgerLine(ref Line_Bottom3Below, leftPoint);
            } else {
                Line_Bottom3Below.Visibility = Visibility.Collapsed;
            }
        }

        private void showLedgerLine(ref Line line, double leftPoint) {
            line.X1 = leftPoint - (lineHeight * .4);
            line.X2 = leftPoint + (2 * lineHeight);
            line.Visibility = Visibility.Visible;
        }

        private bool shouldShowLedgerLine(Line line, double topPoint, double bottomPoint) {
            if (topPoint < Line_Top.Y1) {
                return topPoint < line.Y1;
            }

            if (bottomPoint > Line_Bottom.Y1) {
                return bottomPoint > line.Y1;
            }

            return false;
        }

        private void LayoutRoot_MouseEnter(object sender, MouseEventArgs e) {
            updateEditableArea();
            EditableArea.Visibility = Visibility.Visible;
            Note.Visibility = Visibility.Visible;
        }

        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e) {
            EditableArea.Visibility = Visibility.Collapsed;
            Note.Visibility = Visibility.Collapsed;
        }

        private void updateEditableArea() {
            double leftProperty = LEFT_PADDING;
            double width = this.Width - LEFT_PADDING;
            if (Clef != ClefType.None) {
                leftProperty += clef.GetClefImageWidth(lineHeight);
                width -= clef.GetClefImageWidth(lineHeight);
            }
            EditableArea.SetValue(Canvas.LeftProperty, leftProperty);
            EditableArea.Width = width;
        }

        #endregion Events

        #region Properties & Fields 

        private static double TOP_BOTTOM_PADDING = 10;
        private static double LEFT_PADDING = 10;
        private static int NUMBER_OF_LINES = 11;
        private static int LEDGER_LINE_RADIUS = 10;
        private int lineHeight;

        public ClefType Clef { get; set; }

        private IClef clef;

        public int UserNoteCount { get; set; }

        public bool AllowChords { get; set; }

        #endregion Properties & Fields

    }
}
