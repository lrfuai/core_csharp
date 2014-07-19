using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using LRFLibrary.Functional;
using LRFLibrary.Functional.Positioner;
using LRFLibrary.Functional.Navigator;
using LRFLibrary.Functional.Map;
using LRFLibrary.Functional.Map.Generic;
using LRFLibrary.Functional.Map.Builder;
using LRFLibrary.Functional.Map.Utils;

namespace LRF_Presentation
{
    public partial class Functional : Form
    {
        FunctionalFaccade functionalFaccade;

        public Functional()
        {
            InitializeComponent();
            functionalFaccade = FunctionalFaccade.getInstance();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.functionalFaccade.MapBuilder.MapChanged += MapChangedHandler;
            this.functionalFaccade.Positioner.PositionChanged += PositionChangedHandler;
        }

        private INavigator Navigator() {
            return functionalFaccade.Navigator;
        }

        private void MapChangedHandler(object sender, IMap map)
        {
            this.mapViewer.Image = MapConverter.MapToBmp(map);          
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            this.functionalFaccade.Navigator.move(Movement.TurnLeft);
        }

        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            this.functionalFaccade.Navigator.move(Movement.TurnRight);
        }

        private void btnMoveForward_Click(object sender, EventArgs e)
        {
            this.functionalFaccade.Navigator.move(Movement.Forward);
        }

        private void btnMoveBackward_Click(object sender, EventArgs e)
        {
            this.functionalFaccade.Navigator.move(Movement.Backward);
        }

        private void PositionChangedHandler(object sender, Point position, Direction direction)
        {
            this.lblPosition.Text = position.ToString() + ", " + direction.ToString();
        }
    }
}

