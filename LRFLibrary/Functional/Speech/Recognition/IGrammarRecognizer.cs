using System;
using Microsoft.Speech.Recognition;

namespace LRFLibrary.Functional.Speech.Recognition
{

    public delegate void GRSpeechRecognitionRejected(object sender, GRSpeechRecognitionRejectedEventArgs e);
    public delegate void GRSpeechRecognized(object sender, GRSpeechRecognizedEventArgs e);
    public delegate void GRSpeechHypothesized(object sender, GRSpeechHypothesizedEventArgs e);
    public delegate void GRRecognizeUpdateCompleted(object sender, GRRecognizeUpdateCompletedEventArgs e);
    
    public interface IGrammarRecognizer
    {
        event GRSpeechRecognitionRejected speechRecognitionRejected;
        event GRSpeechRecognized speechRecognized;
        event GRSpeechHypothesized speechHypothesized;
        event GRRecognizeUpdateCompleted recognizerUpdateCompleted;

        void add(GrammarGroup group);
        void remove(GrammarGroup group);
        void update(GrammarGroup group);
        void clearAll();

        void start();
        void stop();
    }
}