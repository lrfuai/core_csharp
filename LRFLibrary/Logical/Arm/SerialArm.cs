using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace LRFLibrary.Logical.Arm
{
    class SerialArm : IArm
    {
        SerialPort serial;

        private struct Joint {
            public const string Wrist = "1";
            public const string Elbow = "2";
            public const string Base = "3";
        }

        public SerialArm(string com, int baudRate, int dataBits)
        {
            serial = new SerialPort(com);
            serial.BaudRate = baudRate;
            serial.DataBits = dataBits;
            serial.Open();
        }

        public void close()
        {
            serial.Close();
        }

        public void moveWristTo(byte postition)
        {
            serial.Write(Joint.Wrist + postition.ToString());
        }

        public void moveElbowTo(byte postition)
        {
            serial.Write(Joint.Elbow + postition.ToString()); 
        }

        public void moveBaseTo(byte postition)
        {
            serial.Write(Joint.Base + postition.ToString()); 
        }


        public void moveShoulderTo(byte postition)
        {
            throw new NotImplementedException();
        }
    }
}
