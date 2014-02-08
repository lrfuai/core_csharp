using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

using LRFLibrary.Functional;
using LRFLibrary.Functional.Image.Detector;
using LRFLibrary.Functional.Image.Recognizer;

namespace LRF_Presentation
{
    public partial class Recognition : Form
    {
        Capture grabber;
        Image<Bgr, Byte> currentFrame;
        
        
        
        public Recognition()
        {
            InitializeComponent();
        }

        private void Recognition_Load(object sender, EventArgs e)
        {
            grabber = new Capture();
            grabber.QueryFrame();
            Application.Idle += new EventHandler(FrameGrabber);
        }

        private void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            imgBoxCapture.Image = currentFrame;
            this.ProcessImage(currentFrame);
        }

        private void ProcessImage(Image<Bgr, Byte> currentFrame)
        {
            
        }
    }
}
