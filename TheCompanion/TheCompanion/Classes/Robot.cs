using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCompanion.Classes
{
    public class Robot
    {
        public int ID
        {
            get; private set;
        }

        public string Name
        {
            get; private set;
        }

        public Robot(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
