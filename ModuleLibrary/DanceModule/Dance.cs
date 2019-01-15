using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace DanceModule
{
    public class DanceModule
    {
        public List<string> Send()
        {
            List<string> listOfCommands = new List<string>();

            listOfCommands.Add("#Move_Left_Arm_Up%");
            listOfCommands.Add("#Move_Right_Arm_Up%");
            listOfCommands.Add("#Move_Left_Arm_Down%");
            listOfCommands.Add("#Move_Right_Arm_Down%");

            return listOfCommands;
        }
    }
}
