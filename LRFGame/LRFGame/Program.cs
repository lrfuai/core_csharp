using System;

namespace LRFGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (KinectSkleton game = new KinectSkleton())
            {
                game.Run();
            }

        }
    }
#endif
}

