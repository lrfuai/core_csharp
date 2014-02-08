using Microsoft.Kinect;
using System.Drawing;

namespace LRFLibrary.Functional.Skeletal.Drawer
{
    interface IDrawer
    {
        void draw(Graphics graphics, Skeleton skel);
        void draw(Graphics graphics, Skeleton skel, JointType type);
        void draw(Graphics graphics, Skeleton skel, JointType typeOne, JointType typeTwo);
    }
}
