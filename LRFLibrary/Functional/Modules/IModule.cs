using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRFLibrary.Functional.Modules
{
    public interface IModule
    {
        void run();
        void stop();
    }
}
