using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloModule
{
    public class Hello
    {
        List<string> listofActions = new List<string>();
        public List<string> Send()
        {
            listofActions.Add("#Move_Left_Arm%");
            listofActions.Add("#Move_Right_Arm%");
            listofActions.Add("#Smile%");


            return listofActions;
        }
    }
}
