using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCompanion.Classes
{
    public class Module
    {
        private string name;
        private dynamic modula;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public dynamic Modula
        {
            get { return modula; }
            set { modula = value; }
        }

        public Module(string name, dynamic module)
        {
            Name = name;
            Modula = module;
        }
    }
}
