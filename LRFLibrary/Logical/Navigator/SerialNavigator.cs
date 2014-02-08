using System;
using System.IO.Ports;

namespace LRFLibrary.Logical.Navigator
{
    class SerialNavigator : INavigator
    {
        SerialPort serial;

        struct Movements {
            public const string Forward = "1";
            public const string Backward = "2";
            public const string Left = "3";
            public const string Right = "4";
        }

        public SerialNavigator(string com, int baudRate, int dataBits)
        {
            serial = new SerialPort(com);
            serial.BaudRate = baudRate;
            serial.DataBits = dataBits;
            serial.Open();
        }

        public void close() {
            serial.Close();
        }

        public void moveFordward()
        {
            serial.Write(Movements.Forward); 
        }
        public void moveBackward()
        {
            serial.Write(Movements.Backward);
        }
        public void turnLeft()
        {
            serial.Write(Movements.Left);
        }
        public void turnRight()
        {
            serial.Write(Movements.Right);
        }
    }
}
