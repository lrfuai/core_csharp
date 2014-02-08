using System;
using Microsoft.Speech.Recognition;

namespace LRFLibrary.Functional.Speech.Recognition
{
    public class GRSpeechRecognitionRejectedEventArgs
    {
        public SpeechRecognitionRejectedEventArgs args {set; get;}

        public GRSpeechRecognitionRejectedEventArgs(SpeechRecognitionRejectedEventArgs args)
        {
            this.args = args;
        }
    }
}
