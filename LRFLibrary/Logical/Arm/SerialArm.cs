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
            public const byte Base = 1;
            public const byte Shoulder = 2;
            public const byte Elbow = 3;
            public const byte Wrist = 4;
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
            serial.Write(createCommand(Joint.Wrist, postition), 0, 3);
        }

        public void moveElbowTo(byte postition)
        {
            serial.Write(createCommand(Joint.Elbow,postition) ,0 ,3); 
        }

        public void moveBaseTo(byte postition)
        {
            serial.Write( createCommand(Joint.Base, postition), 0, 3); 
        }


        public void moveShoulderTo(byte postition)
        {
            serial.Write(createCommand(Joint.Shoulder, postition), 0, 3); 
        }

        private byte[] createCommand(byte joint, byte position)
        {
            byte[] comando = { 255, joint, position };
            return comando;
        }
    }
}
