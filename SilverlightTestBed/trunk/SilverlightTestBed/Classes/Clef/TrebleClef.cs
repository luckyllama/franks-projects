using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SilverlightTestBed.Clef {
    public class TrebleClef : IClef {

        private const double LINE_HEIGHT_HEIGHT_RATIO = 6.95;
        private const double LINE_HEIGHT_WIDTH_RATIO = 2.46;

        #region IClef Members

        public Image GetClefImage(int lineHeight) {
            BitmapImage image = new BitmapImage(new Uri("Content/Images/Clef/treble-clef.png", UriKind.Relative));
            Image result = new Image();
            result.Source = image;
            result.Height = lineHeight * LINE_HEIGHT_HEIGHT_RATIO;

            return result;
        }

        public int GetClefImageWidth(int lineHeight) {
            return (int)(lineHeight * LINE_HEIGHT_WIDTH_RATIO);
        }

        public int GetClefTopPosition(int lineHeight) {
            return (int)(0 - (lineHeight * 1.42));
        }

        #endregion

    }
}
