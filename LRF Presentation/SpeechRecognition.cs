using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using Microsoft.Speech;

using LRFLibrary.Logical;
using LRFLibrary.Functional;
using LRFLibrary.Functional.Speech;
using LRFLibrary.Functional.Speech.Recognition;

namespace LRF_Presentation
{
    public partial class SpeechRecognition : Form
    {
        private LogicalFaccade logical;
        private FunctionalFaccade functional;
        private bool enabled = false;

        private GrammarGroup groupAnimals = new GrammarGroup("Prueba de animales");
        private GrammarGroup groupSalutation = new GrammarGroup("Prueba de Saludos");

        public SpeechRecognition()
        {
            InitializeComponent();
            logical = LogicalFaccade.getInstance();
            functional = FunctionalFaccade.getInstance();
            /*----------------------------------------*/
            Choices saludos = new Choices();
            saludos.Add("hola");
            saludos.Add("chau");
            groupSalutation.add(new Grammar(new GrammarBuilder(saludos)));
            /*----------------------------------------*/
            Choices animals = new Choices();
            animals.Add("perro");
            animals.Add("gato");
            groupAnimals.add(new Grammar(new GrammarBuilder(animals)));
            /*----------------------------------------*/

            functional.SpeechGrammarRecognizer.recognizerUpdateCompleted += GRRecognizerUpdateCompleted;
            functional.SpeechGrammarRecognizer.speechRecognized += GRSpeechRecognized;
        }

        private void SpeechRecognition_Load(object sender, EventArgs e)
        {
            functional.SpeechGrammarRecognizer.add(groupSalutation);
        }

        private void GRSpeechRecognized(object sender, GRSpeechRecognizedEventArgs e)
        {
            if (e.args.Result.Confidence > 0.9)
            {
                MessageBox.Show(e.args.Result.Text);
            }
        }

        private void GRRecognizerUpdateCompleted(object sender, GRRecognizeUpdateCompletedEventArgs e)
        {
            if (! enabled) {
                functional.SpeechGrammarRecognizer.start();
                enabled = true;
            }
            MessageBox.Show("Listo para reconocer.");
        }

        private void btnTalk_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            
            /*
            GrammarBuilder startStop = new GrammarBuilder();
            GrammarBuilder dictation = new GrammarBuilder();
            dictation.AppendDictation();
    
            startStop.Append(new SemanticResultKey("StartDictation", new SemanticResultValue("Start Dictation",true)));
            startStop.Append(new SemanticResultKey("DictationInput", dictation));
            startStop.Append(new SemanticResultKey("StopDictation", new SemanticResultValue("Stop Dictation", false)));
            Grammar grammar=new Grammar(startStop);
            grammar.Enabled=true;
            grammar.Name=" Free-Text Dictation ";
            logical.RecognitionEngine().LoadGrammar(grammar);

            /*
            logical.RecognitionEngine().LoadGrammar(new DictationGrammar());            
            RecognitionResult result = logical.RecognitionEngine().Recognize();
            MessageBox.Show(result.Text);
            */
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            functional.SpeechGrammarRecognizer.add(groupAnimals);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            functional.SpeechGrammarRecognizer.remove(groupAnimals);
        }

        private void btnHablar_Click(object sender, EventArgs e)
        {
            logical.SpeechSynthesizer().Speak("Hola, parece que asi anda");
            logical.SpeechSynthesizer().Speak("Hola, como va");
        }
    }
}
