using System;
using Microsoft.Speech.Recognition;

namespace LRFLibrary.Functional.Speech.Recognition
{
    public class GRSpeechHypothesizedEventArgs
    {
        public SpeechHypothesizedEventArgs args { get; set; }

        public GRSpeechHypothesizedEventArgs(SpeechHypothesizedEventArgs args)
        {
            this.args = args;
        }
    }
}
