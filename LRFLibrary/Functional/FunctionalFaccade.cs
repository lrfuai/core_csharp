using System;
using System.Drawing;

using LRFLibrary.Logical;

namespace LRFLibrary.Functional
{
    using Map.Builder;
    using Positioner;
    using Navigator;
    using Skeletal.Tracking;
    using Speech.Recognition;
    using Speech.Synthesis;
    using Image.Recognizer;
    using LRFLibrary.Functional.Arm;
    using Skeletal.Condition;

    public class FunctionalFaccade
    {
        private static FunctionalFaccade instance;

        private LogicalFaccade logicalFaccade;
        
        public static FunctionalFaccade getInstance()
        {
            if (instance == null)
            {
                instance = new FunctionalFaccade();
            }
            return instance;
        }

        private FunctionalFaccade()
        {
            logicalFaccade = Logical.LogicalFaccade.getInstance();
        }

        private SkeletalTracker tracker;
        public SkeletalTracker SkeletalTracker()
        {
            if (tracker == null)
            {
                tracker = new SkeletalTracker(logicalFaccade.Kinect());
            }
            return tracker;
        }

        private SkeletalSelector selector;
        public SkeletalSelector SkeletalSelector()
        {
            if (selector == null)
            {
                selector = new SkeletalSelector(SkeletalTracker(), new OneHandUp(), new NoHands() );
            }
            return selector;
        }

        private Positioner.Positioner positioner;
        public IPositioner Positioner()
        {
            if (positioner == null)
            {
                positioner = new Positioner.Positioner(new Point(20, 20), Direction.Right);
                Navigator().NavigatorMovement += positioner.NavigatorMovementHandler;
            }
            return positioner;
        }

        private INavigator navigator;
        public INavigator Navigator()
        {
            if (navigator == null)
            {
                navigator = new LinearNavigator(new LogicalNavigatorAdapter(logicalFaccade.Navigator()));
            }
            return navigator;
        }

        private BaseMapBuilder mapBuilder;
        public IMapBuilder MapBuilder()
        {
            if(mapBuilder==null)
            {
                mapBuilder = new BitmapMapBuilder(new Bitmap(400,400));
                //mapBuilder = new BitmapMapBuilder(new Bitmap("C:\\Users\\Dellita-pc\\Desktop\\map.bmp"));
                //mapBuilder = new KinectMapBuilder(Logical.Faccade.getInstance().Kinect());
                Positioner().PositionChanged += mapBuilder.PositionChangedHandler;
            }
            return mapBuilder;
        }

        private GrammarRecognizer speechGrammarRecognizer;
        public IGrammarRecognizer SpeechGrammarRecognizer()
        {
            if (speechGrammarRecognizer == null)
            {
                speechGrammarRecognizer = new GrammarRecognizer(logicalFaccade.RecognitionEngine());
            }
            return speechGrammarRecognizer;
        }
        
        private ISpeechSynthesizer speechSynthesizer;
        public ISpeechSynthesizer SpeechSynthesizer()
        {
            if (speechSynthesizer == null)
            {
                speechSynthesizer = new SpeechSynthesizer(logicalFaccade.SpeechSynthesizer());
            }
            return speechSynthesizer;
        }

        private IArm arm;
        public IArm Arm ()
        {
            if (this.arm == null)
            {
                this.arm = new ArmAdapter(logicalFaccade.Arm());
            }
            return this.arm;
        }
    }
}
