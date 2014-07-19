using System;
using Microsoft.Kinect;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.Globalization;

using LRFLibrary.Logical.Navigator;
using LRFLibrary.Logical.Arm;

namespace LRFLibrary.Logical
{
    public class LogicalFaccade
    {
        private static LogicalFaccade instance;
        
        private LogicalFaccade() {}

        public static LogicalFaccade getInstance()
        {
            if (instance == null)
            {
                instance = new LogicalFaccade();
            }
            return instance;
        }

        private INavigator navigator;
        public INavigator Navigator()
        {
            if (navigator == null)
            {
                //navigator = new SerialNavigator("COM5", 19200, 8);
                navigator = new NoNavigator();
            }
            return navigator;
        }

        private IArm _arm;
        public IArm Arm()
        {
            if (_arm == null)
            {
                _arm = new SerialArm("COM4", 9600, 8);
                //_arm = new NoArm();
            }
            return _arm;
        }

        private KinectSensor sensor;
        public KinectSensor Kinect()
        {
            if (sensor == null)
            {
                foreach (var potentialSensor in KinectSensor.KinectSensors)
                {
                    if (potentialSensor.Status == KinectStatus.Connected)
                    {
                        this.sensor = potentialSensor;
                        break;
                    }
                }
            }
            return sensor;
        }

        private SpeechRecognitionEngine speechRecognitionEngine;
        public SpeechRecognitionEngine RecognitionEngine()
        {
            if (speechRecognitionEngine == null)
            {
                speechRecognitionEngine = new SpeechRecognitionEngine(this.Culture());
                speechRecognitionEngine.SetInputToDefaultAudioDevice();
            }
            return speechRecognitionEngine;
        }

        private CultureInfo culture;
        public CultureInfo Culture()
        { 
            if (culture == null)
            {
                culture = new CultureInfo("es-ES");
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            }
            return culture;
        }

        private SpeechSynthesizer speechSynthesizer;
        public SpeechSynthesizer SpeechSynthesizer()
        {
            if(speechSynthesizer == null)
            {
                speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.SetOutputToDefaultAudioDevice();
            }
            return speechSynthesizer;
        }

    }
}