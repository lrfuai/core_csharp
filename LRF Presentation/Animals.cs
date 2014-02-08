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
    public partial class Animals : Form
    {
        private AnimalsGameModule _animalGame;
        private int iPaso;
        private System.Diagnostics.Process proc = new System.Diagnostics.Process();
        public static string imagePathToShow;
        ImageViewer viewer = new ImageViewer();
        
        public Animals()
        {
            InitializeComponent();
            this._animalGame = new AnimalsGameModule(
                FunctionalFaccade.getInstance().SpeechGrammarRecognizer(),
                FunctionalFaccade.getInstance().SpeechSynthesizer(),
                FunctionalFaccade.getInstance().Navigator(),
                0.7
            );

            this._animalGame.animalsGameSpeechRecognized += _animalGame_animalsGameSpeechRecognized;
        }

        private void _animalGame_animalsGameSpeechRecognized(object sender, AnimalsGameSpeechRecognizedEventArgs e)
        {
            //e.LastRecognized;
            //e.Recognized
            string animal = e.Recognized;
            viewer.changeTitle(animal.ToLower() + " (" + e.Confidence.ToString("P") + ")");
            viewer.showImage("C:/perrobot/imagenes/animales/" + animal.ToLower() + ".jpg");
        }

        private void btnConfidence_Click(object sender, EventArgs e)
        {
            try
            {
                _animalGame.Confidence = Double.Parse(txtConfidence.Text);
            }
            catch (Exception exep) { /*No pudo parsear la confianza*/ }

            txtConfidence.Text = _animalGame.Confidence.ToString();
        }

        public void Cerrar()
        {
            Application.Exit();  
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _animalGame.run();
            FunctionalFaccade.getInstance().SpeechGrammarRecognizer().start();
            _tournButtons();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _animalGame.stop();
            FunctionalFaccade.getInstance().SpeechGrammarRecognizer().stop();
            _tournButtons();
        }

        private void _tournButtons()
        {
            btnStart.Enabled = !btnStart.Enabled;
            btnStop.Enabled = !btnStop.Enabled;

            if (btnStop.Enabled) 
            { 
                btnStop.BackColor = Color.LightCyan; 
            
            }
            else { btnStop.BackColor = Color.DarkCyan; }

            if (btnStart.Enabled)
            { btnStart.BackColor = Color.LightCyan;
            tBox_Msg.Text = "Sistema de reconocimiento de voz desactiva";
            }
            else { btnStart.BackColor = Color.DarkCyan;
            
            tBox_Msg.Text = "Sistema de reconocimiento de voz iniciado";
            }
        }

        private void Animals_Load(object sender, EventArgs e)
        {
            viewer.Show();
            txtConfidence.Text = _animalGame.Confidence.ToString();
            btnStop.Enabled = false;
            btnStop.BackColor = Color.Gray;
            btnStart.Enabled = true;
            btnStart.BackColor = Color.LightCyan;
           // drawCircle(100, 100);
        }

        private void drawCircle(int x, int y)
        {
                    //Espero de dibujo (color, ancho)    
            Pen pen = new Pen(Color.Blue,1);     
            Graphics graphics = this.CreateGraphics();     //Linea     
            graphics.DrawLine(pen, 0, 0, 50, 50);     
            Font font= new Font("Verdana", 8, FontStyle.Underline);     //Texto     
            graphics.DrawString("Hello", font, new SolidBrush(Color.Red), 50, 200);     //Rectangulo   
            graphics.FillRectangle(new SolidBrush(Color.Red ), 100,100, 200, 200);
             


            Bitmap b;
            b = new Bitmap(pBox_Animal.Width, pBox_Animal.Height);
            pBox_Animal.Image = (Image)b;
            Graphics g = Graphics.FromImage(b);
            g.DrawEllipse(pen, 0, 0, 10, 10);

            SolidBrush SBrush = new SolidBrush(Color.Blue);
            g.FillEllipse(SBrush, 0, 0, 10, 10);
            

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap b;
            b = new Bitmap(pBox_Animal.Width, pBox_Animal.Height);
            pBox_Animal.Image = (Image)b;
            Graphics g = Graphics.FromImage(b);
            Pen pen = new Pen(Color.Blue, 1);
            SolidBrush SBrush = new SolidBrush(Color.Blue);

            iPaso++;

            if ((iPaso %2) == 0)
            {
                pen.Color = Color.Green;
                SBrush.Color = Color.Green;
            }
            else
            {
                pen.Color = Color.GreenYellow;
                SBrush.Color = Color.GreenYellow;
            }

            if (iPaso < 5)
            {
                pen.Color = Color.Transparent;
                SBrush.Color = Color.Transparent;
            }

            if (iPaso > 10)
            {
                iPaso = 0;
                pen.Color = Color.Transparent;
                SBrush.Color = Color.Transparent;
            }

      /*      switch (iPaso)
            {
                case 1:
                   pen.Color = Color.Blue;
                   SBrush.Color = Color.Blue;
                    
                    break;
                case 2:
                    pen.Color = Color.RoyalBlue;
                    SBrush.Color = Color.RoyalBlue ;
                    break;
                case 3:
                    break;
                case 4:
                    pen.Color = Color.Transparent;
                    SBrush.Color = Color.Transparent;
                    iPaso = 0;
                    break;
            }*/

            g.DrawEllipse(pen, 10 - iPaso, 10 - iPaso, 20 + iPaso * 2, 20 + iPaso * 2);
            g.FillEllipse(SBrush, 10 - iPaso, 10 - iPaso, 20 + iPaso * 2, 20 + iPaso * 2);
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            proc.EnableRaisingEvents = false;
            //Llamar a calculadora 
            //proc.StartInfo.FileName = "calc"; 
            //Llamar a MS paintbrush 
            proc.StartInfo.FileName = "mspaint";
       
            //Llamar al manejador de servicios de Windows 
            //proc.StartInfo.FileName = "services.msc"; 
            //Llamar al Event Viewer 


            proc.Start(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "chrome";
            proc.StartInfo.Arguments = "http://www.google.com";
            //proc.st= System.Diagnostics.ProcessWindowStyle.Maximized;
            proc.Start();
            proc.WaitForExit(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true; // Vuelve al directorio actual

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(openFileDialog.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            proc.Kill(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            proc.StartInfo.FileName = "calc";
            proc.Start(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{WIN}{M}");
        }

    }
}
