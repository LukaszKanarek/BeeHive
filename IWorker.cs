using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive
{
    internal interface IWorker
    {
        public string Job
        {
            get; 
        }

        void WorkNextShift();
    }
}
