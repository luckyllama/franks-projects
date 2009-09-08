using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightTestBed.Clef {
    public interface IClef {

        /// <summary>
        /// Gets the image control of the clef.
        /// </summary>
        /// <param name="lineHeight">The distance between two lines on the staff.</param>
        /// <returns></returns>
        Image GetClefImage(int lineHeight);

        /// <summary>
        /// Gets the top position (in +/- pixels) of the image relative to the top line of the staff.
        /// </summary>
        /// <param name="lineHeight">The distance between two lines on the staff.</param>
        /// <returns></returns>
        int GetClefTopPosition(int lineHeight);

    }
}
