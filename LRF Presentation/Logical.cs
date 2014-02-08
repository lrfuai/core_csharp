using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LRFLibrary.Logical;
using LRFLibrary.Logical.Navigator;

namespace LRF_Presentation
{
    public partial class Logical : Form
    {
        LogicalFaccade logical;
        INavigator navigator;

        public Logical()
        {
            InitializeComponent();
            logical = LogicalFaccade.getInstance();
        }

        private void Logical_Load(object sender, EventArgs e)
        {
            navigator = logical.Navigator();
        }

        private void btnMoveForward_Click(object sender, EventArgs e)
        {
            navigator.moveFordward();
        }

        private void btnMoveBackward_Click(object sender, EventArgs e)
        {
            navigator.moveBackward();
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            navigator.turnLeft();
        }

        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            navigator.turnRight();
        }
    }
}
