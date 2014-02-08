using System;
using Microsoft.Speech.Recognition;

namespace LRFLibrary.Functional.Speech.Recognition
{
    public class GRSpeechRecognizedEventArgs
    {
        public SpeechRecognizedEventArgs args { get; set; }

        public GRSpeechRecognizedEventArgs(SpeechRecognizedEventArgs args)
        {
            this.args = args;
        }
    }
}
