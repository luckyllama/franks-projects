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

namespace SilverlightTestBed.Notes {

    [Flags]
    public enum NoteOptions {
        Flat = 1,
        Sharp = 2,
        Natural = 4,
        DoubleFlat = 8,
        DoubleSharp = 16,
        Dotted = 32
    }
}
