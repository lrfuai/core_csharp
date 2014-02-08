using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class HandsTogether : ISkeltalCondition
    {
        private double delta;
        public HandsTogether(double unDelta)
        {
            this.delta = unDelta;
        }
        bool ISkeltalCondition.apply(Skeleton skel)
        {
            throw new NotImplementedException();
        }
    }
}
