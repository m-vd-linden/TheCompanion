using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCompanion.Classes
{
    public class Challenge
    {
        public string Name
        {
            get; private set;
        }

        public int Progress
        {
            get; private set;
        }

        public Challenge(string name, int progress)
        {
            Name = name;
            Progress = progress;
        }
    }
}
