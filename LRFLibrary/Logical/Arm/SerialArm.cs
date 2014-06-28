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
        const float maxDegrees = 90;
        const float minDegrees = 0;

        //Primer byte siempre 255 de Inicialización
        byte[] comando = { 255, 0, 0 };


        private struct Joint {
            public const int Base     = 1;
            public const int Shoulder = 2;
            public const int Elbow = 3;
            public const int Wrist = 4;
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

        public void moveWristTo(float degree)
        {
            writeSerial(Joint.Wrist, degree);                                    
        }

        public void moveElbowTo(float degree)
        {
            writeSerial(Joint.Elbow, degree);                                    
        }

        public void moveBaseTo(float degree)
        {
            writeSerial(Joint.Base, degree);                                    
        }

        public void moveShoulderTo(float degree)
        {
            writeSerial(Joint.Shoulder, degree);                                    
        }

        private void writeSerial(int joint, float degree)
        {
            //Segundo byte es el servomotor
            comando[1] = (byte)joint;
            //Tercer byte es la posicion entre 0 y 254.
            if (degree >= maxDegrees)
            {
                degree = maxDegrees;
            }
            if (degree <= minDegrees)
            {
                degree = minDegrees;
            }

            byte position = (byte)(degree * 254 / 90);

            comando[2] = position;
            serial.Write(comando, 0, 3);        
        }
    }
}
