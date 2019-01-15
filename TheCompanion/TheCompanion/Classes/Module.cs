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

        public string Name
        {
            get; private set;
        }

        public string ScriptLocation
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + location; }
            private set { location = value; }
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
                List<string> tempList = new List<string>();
                tempList = d.Send();

                foreach (string item in tempList)
                {
                    Console.WriteLine(item);
                }
            }

            return listOfStrings;
        }
    }
}
