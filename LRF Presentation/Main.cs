using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LRFLibrary.Functional;
using LRFLibrary.Functional.Modules;

namespace LRF_Presentation
{
    public partial class Main : Form
    {
        private MainModule _mainModule;

        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {

            
            this._mainModule = new MainModule(
                FunctionalFaccade.getInstance().SpeechGrammarRecognizer,
                FunctionalFaccade.getInstance().SpeechSynthesizer,
                0.7
            );
            _mainModule.run();
            FunctionalFaccade.getInstance().SpeechGrammarRecognizer.start();
        }
    }
}
