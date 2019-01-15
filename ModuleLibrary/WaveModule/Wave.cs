using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WaveModule
{
    public class WaveModule
    {
        List<string> listofActions = new List<string>();
        public List<string> Send()
        {
            listofActions.Add("#Move_Left_Arm_Up%");
            listofActions.Add("#Move_Right_Arm_Down%");
            listofActions.Add("#Smile%");
            return listofActions;
        }
    }
}
