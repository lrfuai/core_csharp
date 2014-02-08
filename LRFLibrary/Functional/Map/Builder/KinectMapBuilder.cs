using System;
using Microsoft.Kinect;

namespace LRFLibrary.Functional.Map.Builder
{
    class KinectMapBuilder : BaseMapBuilder
    {
        private KinectSensor sensor;

        public KinectMapBuilder(KinectSensor sensor)
        {
            this.sensor = sensor;
        }
    }
}
