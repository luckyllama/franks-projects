using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SilverlightTestBed.Clef {
    public class TrebleClef : IClef {

        #region IClef Members

        public Image GetClefImage(int lineHeight) {
            BitmapImage image = new BitmapImage(new Uri("Content/Images/Clef/treble-clef.png", UriKind.Relative));
            Image result = new Image();
            result.Source = image;
            result.Height = lineHeight * 6.95;

            return result;
        }

        public int GetClefTopPosition(int lineHeight) {
            return (int)(0 - (lineHeight * 1.42));
        }

        #endregion
    }
}
