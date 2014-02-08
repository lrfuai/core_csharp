using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Speech.Synthesis
{
    public interface ISpeechSynthesizer
    {
        void Speak(string text);
    }
}
