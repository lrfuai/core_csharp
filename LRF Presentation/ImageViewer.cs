using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRF_Presentation
{
    public partial class ImageViewer : Form
    {
        public ImageViewer()
        {
            InitializeComponent();
        }

        private void AnimalsViewer_Load(object sender, EventArgs e)
        {
            clearImage();
        }

        public void changeTitle(string title) {
            this.Text = title;
        }

        public void showImage(string path)
        {
            if (File.Exists(path))
            {
                pictureBoxAnimals.Image = new Bitmap(path);
            }
            else
            {
                clearImage();
            }
        }

        public void clearImage()
        {
            pictureBoxAnimals.Image = new Bitmap("C:/perrobot/imagenes/default.jpg");
        }
    }
}
