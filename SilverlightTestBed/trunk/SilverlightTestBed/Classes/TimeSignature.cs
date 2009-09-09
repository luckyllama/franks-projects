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

namespace SilverlightTestBed {
    public class TimeSignature {

        public TimeSignature(int beatUnit, int beatPerBar) {
            this.BeatUnit = beatUnit;
            this.BeatPerBar = beatPerBar;
        }

        public int BeatUnit { get; private set; }
        public int BeatPerBar { get; private set; }

        public bool AllowCommonTimeNotation { get; set; }
    }
}
