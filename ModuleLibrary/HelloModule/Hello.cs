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
        public List<string> Send(int skill)
        {
            switch (skill)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    break;

                case 7:
                    break;

                case 8:
                    break;

                case 9:
                    break;
            }

            listofActions.Add("#Move_Left_Arm%");
            listofActions.Add("#Move_Right_Arm%");
            listofActions.Add("#Smile%");


            return listofActions;
        }
    }
}
