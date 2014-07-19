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
using LRFLibrary.Functional.Arm;

namespace LRF_Presentation
{
    public partial class Arm : Form
    {
        IArm Brazo;

        public Arm()
        {
            InitializeComponent();
            Brazo = FunctionalFaccade.getInstance().Arm;
        }

        private void Arm_Load(object sender, EventArgs e)
        {
            //BrasilDecimeQueSeSiente();
            Brazo.moveElbowTo(47);
            ElbowTxt.Text = "47";
            Brazo.moveShoulderTo(60);
            ShoulderTxt.Text = "60";
            Brazo.moveWristTo(81);
            WristTxt.Text = "81";
            Brazo.moveBaseTo(52);
            BaseTxt.Text = "52";
        }

        public void BrasilDecimeQueSeSiente()
        {
            int sleep = 3;
            while (true) { 
                for (int i = 0; i <= 200; i++)
                {
                    Brazo.moveBaseTo(i);
                    Brazo.moveWristTo(100 + Math.Abs(i / 2));
                    System.Threading.Thread.Sleep(sleep);
                }
                for (int i = 200; i <= 0; i--)
                {
                    Brazo.moveBaseTo(i);
                    Brazo.moveWristTo(100 + Math.Abs(i / 2));
                    System.Threading.Thread.Sleep(sleep);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MOV DE CODO
            Brazo.moveElbowTo(float.Parse(ElbowTxt.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // MOV DE HOMBRO
            Brazo.moveShoulderTo(float.Parse(ShoulderTxt.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // MOV DE MUÑECA
            Brazo.moveWristTo(float.Parse(WristTxt.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // MOV DE BASE
            Brazo.moveBaseTo(float.Parse(BaseTxt.Text));
        }
    }
}
