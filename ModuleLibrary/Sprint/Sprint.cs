using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint
{
    public class Sprint
    {
        List<string> listofActions = new List<string>();
        public List<string> Send(int skill)
        {
            switch (skill)
            {
                case 1:
                    listofActions.Add("#DRIVEFORWARD<100>%");
                    break;

                case 2:
                    listofActions.Add("#DRIVEFORWARD<200>%");
                    break;

                case 3:
                    listofActions.Add("#DRIVEFORWARD<300>%");
                    break;

                case 4:
                    listofActions.Add("#DRIVEFORWARD<400>%");
                    break;

                case 5:
                    listofActions.Add("#DRIVEFORWARD<500>%");
                    break;

                case 6:
                    listofActions.Add("#DRIVEFORWARD<600>%");
                    break;

                case 7:
                    listofActions.Add("#DRIVEFORWARD<700>%");
                    break;

                case 8:
                    listofActions.Add("#DRIVEFORWARD<800>%");
                    break;

                case 9:
                    listofActions.Add("#DRIVEFORWARD<900>%");
                    break;
            }
            return listofActions;
        }
    }
}
