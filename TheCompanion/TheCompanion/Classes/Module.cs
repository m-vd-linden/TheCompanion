using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheCompanion.Classes
{
    public class Module
    {
        private string location;
        private int skillCounter;

        public string Name
        {
            get; private set;
        }

        public string ScriptLocation
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + location; }
            private set { location = value; }
        }

        public int Skill
        {
            get; private set;
        }

        public Module(string name, string location)
        {
            Name = name;
            ScriptLocation = location;
        }

        public List<string> Execute()
        {
            List<string> listOfStrings = new List<string>();

            Assembly module = Assembly.LoadFile(ScriptLocation);

            foreach (Type t in module.GetExportedTypes())
            {
                dynamic d = Activator.CreateInstance(t);
                listOfStrings = d.Send();
            }

            return listOfStrings;
        }
    }
}
