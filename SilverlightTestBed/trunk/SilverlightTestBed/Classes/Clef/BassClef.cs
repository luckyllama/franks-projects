using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SilverlightTestBed.Clef {
    public class BassClef : IClef {

        #region IClef Members

        public Image GetClefImage(int lineHeight) {
            BitmapImage image = new BitmapImage(new Uri("Content/Images/Clef/bass-clef.png", UriKind.Relative));
            Image result = new Image();
            result.Source = image;
            result.Height = lineHeight * 3.3;

            return result;
        }

        public int GetClefTopPosition(int lineHeight) {
            return 0;
        }

        #endregion
    }
}
