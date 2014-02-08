using System;
using System.Collections.Generic;
using Microsoft.Speech;
using Microsoft.Speech.Recognition;

namespace LRFLibrary.Functional.Speech.Recognition
{
    class GrammarRecognizer : IGrammarRecognizer
    {
        public event GRSpeechRecognitionRejected speechRecognitionRejected;
        public event GRSpeechRecognized speechRecognized;
        public event GRSpeechHypothesized speechHypothesized;

        public event GRRecognizeUpdateCompleted recognizerUpdateCompleted;

        private SpeechRecognitionEngine engine;
        private List<GrammarGroup> grammarGroups = new List<GrammarGroup>();

        public GrammarRecognizer(SpeechRecognitionEngine engine)
        {
            this.engine = engine;
            this.engine.RecognizerUpdateReached     += RecognizerUpdateReached;
            this.engine.SpeechRecognized            += SpeechRecognizedHandler;
            this.engine.SpeechRecognitionRejected   += SpeechRecognitionRejectedHandler;
            this.engine.SpeechHypothesized          += SpeechHypothesizedHandler;
        }

        public void add(GrammarGroup group)
        {
            grammarGroups.Remove(group);
            grammarGroups.Add(group);
            engine.RequestRecognizerUpdate(new UpdateGrammarRequest(GrammarRequestType.LoadGrammar, group));
        }

        public void remove(GrammarGroup group)
        {
            grammarGroups.Remove(group);
            engine.RequestRecognizerUpdate(new UpdateGrammarRequest(GrammarRequestType.UnloadGrammar, group));
        }

        public void update(GrammarGroup group)
        {
            grammarGroups.Remove(group);
            grammarGroups.Add(group);
            engine.RequestRecognizerUpdate(new UpdateGrammarRequest(GrammarRequestType.UpdateGrammar, group));
        }

        public void clearAll()
        {
            grammarGroups.Clear();
            engine.UnloadAllGrammars();
        }

        private void RecognizerUpdateReached(object sender, RecognizerUpdateReachedEventArgs e)
        {
            var request = e.UserToken as UpdateGrammarRequest;
            if (request == null)
                return;

            switch (request.Type)
            {
                case GrammarRequestType.LoadGrammar:
                    foreach (Grammar grammars in request.Group.Grammars)
                    {
                        engine.LoadGrammar(grammars);
                    }

                    if (this.recognizerUpdateCompleted != null)
                    {
                        this.recognizerUpdateCompleted(this, new GRRecognizeUpdateCompletedEventArgs());
                    }
                break;
                case GrammarRequestType.UnloadGrammar:
                    foreach (Grammar grammars in request.Group.Grammars)
                    {
                        engine.UnloadGrammar(grammars);
                    }
                    if (this.recognizerUpdateCompleted != null)
                    {
                        this.recognizerUpdateCompleted(this, new GRRecognizeUpdateCompletedEventArgs());
                    }
                break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        } 

        private void SpeechHypothesizedHandler(object sender, SpeechHypothesizedEventArgs e)
        {
            if (this.speechHypothesized != null)
            {
                this.speechHypothesized(this, new GRSpeechHypothesizedEventArgs(e));
            }
        }

        private void SpeechRecognitionRejectedHandler(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            if (this.speechRecognitionRejected != null)
            {
                this.speechRecognitionRejected(this, new GRSpeechRecognitionRejectedEventArgs(e));
            }
        }

        private void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
        {
            if (this.speechRecognized != null)
            {
                this.speechRecognized(this, new GRSpeechRecognizedEventArgs(e));
            }
        }

        public void start()
        {
            this.engine.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void stop()
        {
            this.engine.RecognizeAsyncStop();
        }
    }
}
