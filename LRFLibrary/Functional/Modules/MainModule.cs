using System;
using Microsoft.Speech.Recognition;

namespace LRFLibrary.Functional.Modules
{
    using Speech.Recognition;
    using Speech.Synthesis;

    public class MainModule : IModule
    {
        private IGrammarRecognizer _recognizer;
        private ISpeechSynthesizer _synthesizer;
        private Double _confidence;
        private GrammarGroup _optionsGrammar;
        private IModule _currentModule;
        private IGrammarRecognizer grammarRecognizer;
        private ISpeechSynthesizer speechSynthesizer;
        private double p;

        public MainModule(IGrammarRecognizer recognizer, ISpeechSynthesizer synthesizers, double confidence = 0.5)
        {
            _recognizer = recognizer;
            _synthesizer = synthesizers;
            _confidence = confidence;
            _loadGrammar();
            _recognizer.add(_optionsGrammar);
        }

        private void _loadGrammar()
        {
            _optionsGrammar = new GrammarGroup("Menu Principal");
            GrammarBuilder activacionPhrase = new GrammarBuilder("Activar modulo");
            activacionPhrase.Append(getGrammarModules());

            GrammarBuilder desactivacionPhrase = new GrammarBuilder("Desactivar modulos");

            Choices administrationChoices = new Choices(new GrammarBuilder[] { activacionPhrase, desactivacionPhrase });

            Grammar administrationGrammar = new Grammar((GrammarBuilder)administrationChoices);
            administrationGrammar.Name = "Administration";
            _optionsGrammar.add(administrationGrammar);

            /*
            functional.SpeechGrammarRecognizer().recognizerUpdateCompleted += GRRecognizerUpdateCompleted;
            functional.SpeechGrammarRecognizer().speechRecognized += GRSpeechRecognized;  
            */
        }

        private Choices getGrammarModules()
        {
            Choices modules = new Choices();
            modules.Add("seguimiento");
            modules.Add("animales");
            return modules;
        }

        private void _speechRecognized(object sender, GRSpeechRecognizedEventArgs e)
        {
            if (e.args.Result.Confidence >= _confidence)
            {
                
            }
        }

        public void run()
        {
            _recognizer.speechRecognized += this._speechRecognized;
        }

        public void stop()
        {
            _recognizer.speechRecognized -= this._speechRecognized;
        }
    }
}
