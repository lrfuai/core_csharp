using System;
using Microsoft.Kinect;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public interface ISkeltalCondition
    {
        bool apply(Skeleton skel);
    }
}
