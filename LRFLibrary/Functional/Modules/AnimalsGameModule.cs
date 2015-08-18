using System;  
using Microsoft.Speech.Recognition;
using System.Globalization;

namespace LRFLibrary.Functional.Modules
{
    using Speech.Recognition;
    using Speech.Synthesis;
    using Navigator;
    using System.Threading;

    public delegate void AnimalsGameSpeechRecognized(object sender, AnimalsGameSpeechRecognizedEventArgs animal);

    public class AnimalsGameSpeechRecognizedEventArgs
    {
        public string Recognized { get; set; }
        public string LastRecognized { get; set; }
        public double Confidence { get; set; }
        
        public AnimalsGameSpeechRecognizedEventArgs(string recognized, double confidence, string lastRecognized)
        {
            this.Recognized = recognized;
            this.Confidence = confidence;
            this.LastRecognized = lastRecognized;
        }
    }

    public class AnimalsGameModule : IModule
    {
        private IGrammarRecognizer _recognizer;
        private ISpeechSynthesizer _synthesizer;
        private INavigator _navigator;
        public Double Confidence { set; get; }
        private GrammarGroup _animalsGramar;

        private DateTime lastRecognitionDate;
        private string lastRecognition;

        public event AnimalsGameSpeechRecognized animalsGameSpeechRecognized;
       
        public AnimalsGameModule(IGrammarRecognizer recognizer, ISpeechSynthesizer synthesizer, INavigator navigator, Double confidence = 0.5)
        {
            _recognizer = recognizer;
            _synthesizer = synthesizer;
            _navigator = navigator;
            Confidence = confidence;
            _loadGrammar();
            _recognizer.add(_animalsGramar);

            RefactorizameSiTenesDignidad.recognizer = recognizer;
            RefactorizameSiTenesDignidad.synthesizer = synthesizer;
            RefactorizameSiTenesDignidad.navigator = navigator;
        }
        
        private void _speechRecognized(object sender, GRSpeechRecognizedEventArgs e)
        {
            string sResult = e.args.Result.Semantics.Value.ToString();

            DateTime dEndTime = DateTime.Now;

            TimeSpan daysDiff = dEndTime.Subtract(lastRecognitionDate);

            //ingresa si es distinta la palabra y si pasaron mas de 5 segundos
            if ((sResult != lastRecognition) || (daysDiff.Seconds >= 5) || (daysDiff.Minutes > 0))
            {
                if (e.args.Result.Confidence >= Confidence)
                {
                    if (this.animalsGameSpeechRecognized != null)
                    {
                        this.animalsGameSpeechRecognized(this, new AnimalsGameSpeechRecognizedEventArgs(sResult, e.args.Result.Confidence, lastRecognition));
                    }
                    lastRecognition = sResult;
                    lastRecognitionDate = DateTime.Now;
                    _makeSoundOf(e.args.Result.Semantics.Value.ToString());
                }
            }
                
        }

        private void _makeSoundOf(string animal)
        {
            RefactorizameSiTenesDignidad.makeSoundOf(animal);
            //_synthesizer.Speak(animal);
        }

        public void run()
        {
            _recognizer.speechRecognized += this._speechRecognized;
            _recognizer.start();
        }

        public void stop()
        {
            _recognizer.speechRecognized -= this._speechRecognized;
            _recognizer.stop();
        }

        private void _loadGrammar()
        {
            _animalsGramar = new GrammarGroup("AnimalGame");
            _animalsGramar.add(new Grammar(@"C:/perrobot/audio/animales/SpeechGrammar.xml"));
        }
    }

    static class RefactorizameSiTenesDignidad
    {
        public static IGrammarRecognizer recognizer { get; set; }
        public static ISpeechSynthesizer synthesizer { get; set; }
        public static INavigator navigator { get; set; }

        private static string _pathSonidosBase = "C:/perrobot/audio/";
      

        public static void makeSoundOf(string animal)
        {
            switch (animal.ToUpper())
            {
                case "NO_DESACTIVAR_SISTEMA":
                    synthesizer.Speak("No me quiero desactivar señor");
                    break;
                case "DECIR_FECHA":
                    CultureInfo ci = new CultureInfo("Es-Es");
                    synthesizer.Speak("El día de hoy es " + ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)  + DateTime.Now.ToString("dd-MM-yyyy"));
                    break;
                case "ACTIVAR_COMANDOS":
                    synthesizer.Speak("Sistema de comandos activado");
                    break;
                case "ACTIVAR_SEGUIDOR":
                    synthesizer.Speak("Sistema de seguimiento de personas activado");
                    break;
                case "ACTIVAR_INTERFACE_VISUAL":
                    synthesizer.Speak("Sistema de interfas visual activado");
                    break;
                case "CALCULADORA":
                    System.Diagnostics.Process.Start(@"CALC.EXE");
                    break;
                case "NAVEGADOR":
                    System.Diagnostics.Process.Start(@"CHROME.EXE");
                    break;
                case "NOTEPAD":
                    System.Diagnostics.Process.Start(@"NOTEPAD.EXE");
                    break;
                case "SOS_EDUCADA":
                    synthesizer.Speak("Gracias; así es. trato de interactuar de la mejor forma posible con los humanos");
                    break;
                case "ACTIVAR_SISTEMA":
                    synthesizer.Speak("Sistema SARA activado");
                    break;
                case "DESACTIVAR_SISTEMA":
                    synthesizer.Speak("Sistema SARA desactivado");
                    break;
                case "DECIR_HORA":
                   synthesizer.Speak("La hora actual es " + DateTime.Now.ToString("HH:mm:ss"));
                    break;
                case "GRACIAS":
                    synthesizer.Speak("gracias a ti");
                    break;
                case "LADRAR" :
                    RefactorizameSiTenesDignidad.reproducegenericSound("animales","dog.wav"); break;
                case "MONO" :
                    RefactorizameSiTenesDignidad.reproducegenericSound("animales","monkey_sound.wav"); break;
                case "PICACHU" :
                    RefactorizameSiTenesDignidad.reproducegenericSound("animales","pikachu.wav"); break;
                case "WALLY" :
                    RefactorizameSiTenesDignidad.reproducegenericSound("robot","wall-e.wav"); break;
                case "ARTURITO" :
                    RefactorizameSiTenesDignidad.reproducegenericSound("robot","r2d2.wav"); break;
                case "TERMINEITOR" :
                    RefactorizameSiTenesDignidad.reproducegenericSound("robot","terminator_hasta_la_vista.wav"); break;
                case "SALUDAR":
                    synthesizer.Speak( "Hola, " + getDaysegment() ); break;
                case "NOMBRE":
                    //synthesizer.Speak("Me llamo Robin. Robot de Interfaz Natural"); 
                    //synthesizer.Speak("Me llamo Sara. Software Autonomo de Robotica Aplicada.");
                    synthesizer.Speak("Me llamo SARA");
                    break;
                case "NOMBRE_SIGNIFICADO":
                    //synthesizer.Speak("Me llamo Robin. Robot de Interfaz Natural"); 
                    synthesizer.Speak("Es el acronimo de 'Software Autonomo de Robotica Aplicadá'. Es un Software multiproposito desarrollado en el Laboratorio de Robotica Fisica de la universidad abierta interamericana.");     
                    break;
                case "FABRICADO_POR":
                    synthesizer.Speak("fui fabricado por el ingeniero nestor balich y los estudiantes alejandro cena y franco balich"); break;
                case "FABRICADO_DONDE":
                    synthesizer.Speak("me fabricaron en el laboratorio de robótica física de la universidad abierta interamericana"); break;
                case "IMITAS_ANIMALES":
                    synthesizer.Speak("Sí, imito muy bien algunos de ellos. Nómbrame uno y veamos si me sale bien"); break;
                case "CHAU":
                    synthesizer.Speak("chau! gracias por visitarnos. Saludos y vuelve cuando quieras."); break;
                case "BAILAR":
                    RefactorizameSiTenesDignidad.bailar(); break;
                default:
                    RefactorizameSiTenesDignidad.reproducegenericSound("animales", animal.ToLower() + ".wav");
                    break;
            }
           // RefactorizameSiTenesDignidad.recognizer.stop();
              
           // Thread.Sleep(1000);// es para no repetir la lectura refactorizame si tenes cara
           // RefactorizameSiTenesDignidad.recognizer.start( );
        }

        public static string getDaysegment()
        {
            string segmento = "";

            if (DateTime.Now.Hour < 12)
            {
                segmento = "Buen día";
            }
            else if (DateTime.Now.Hour < 19)
            {
                segmento = "Buenas tardes";
            }
            else
            {
                segmento = "Buenas noches";
            }
            return segmento;
        }

        public static void reproducegenericSound(string stipo, string file)
        {
            try
            {
                RefactorizameSiTenesDignidad.recognizer.stop();
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(_pathSonidosBase + stipo + "/wav/" + file);
                //snd.PlaySync(); //es sincronico con lo cual no vuelve hasta teminar de reproducir refactorizame si tenes cara
                snd.Play();
                RefactorizameSiTenesDignidad.recognizer.start();
            }
            catch (Exception e) {
                
            }
        }

        public static void bailar() {
            reproducegenericSound("sonidos","robotique.wav");
            navigator.move(Movement.Forward);
            navigator.move(Movement.Backward);
            navigator.move(Movement.Forward);
            navigator.move(Movement.Backward);
            navigator.move(Movement.TurnRight);
            navigator.move(Movement.TurnRight);
            navigator.move(Movement.TurnLeft);
            navigator.move(Movement.TurnLeft);
            navigator.move(Movement.TurnLeft);
            navigator.move(Movement.TurnRight);
            navigator.move(Movement.TurnRight);
            navigator.move(Movement.TurnLeft);
            navigator.move(Movement.TurnLeft);
            System.Threading.Thread.Sleep(400);
            navigator.move(Movement.Backward);
        }
    }
}
