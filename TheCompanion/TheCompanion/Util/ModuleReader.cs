using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace TheCompanion.Util
{
    public class ModuleReader
    {
        static string STARTUPLOCATION = AppDomain.CurrentDomain.BaseDirectory;

        DirectoryInfo dInfo = new DirectoryInfo(STARTUPLOCATION + @"/Modules");
    }
}
