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
            Brazo.moveElbowTo(47);
            Brazo.moveShoulderTo(60);
            Brazo.moveWristTo(81);
            Brazo.moveBaseTo(52);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MOV DE CODO
            Brazo.moveElbowTo(float.Parse(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // MOV DE HOMBRO
            Brazo.moveShoulderTo(float.Parse(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // MOV DE MUÑECA
            Brazo.moveWristTo(float.Parse(textBox1.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // MOV DE BASE
            Brazo.moveBaseTo(float.Parse(textBox4.Text));
        }
    }
}
