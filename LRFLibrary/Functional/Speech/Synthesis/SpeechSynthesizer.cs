using MicrosoftSynthesis = Microsoft.Speech.Synthesis;

namespace LRFLibrary.Functional.Speech.Synthesis
{
    class SpeechSynthesizer : ISpeechSynthesizer
    {
        MicrosoftSynthesis.SpeechSynthesizer speechSynthesizer;

        public SpeechSynthesizer(MicrosoftSynthesis.SpeechSynthesizer speechSynthesizer)
        {
            this.speechSynthesizer = speechSynthesizer;
        }

        public void Speak(string text)
        {
            this.speechSynthesizer.Speak(text);
        }
    }
}
