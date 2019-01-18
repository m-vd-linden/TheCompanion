using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleModule
{
    public class Circle
    {
        List<string> listofActions = new List<string>();
        public List<string> Send(int skill)
        {
            switch (skill)
            {
                case 1:
                    listofActions.Add("#DRIVERIGHT<100>%");
                    break;

                case 2:
                    listofActions.Add("#DRIVERIGHT<200>%");
                    break;

                case 3:
                    listofActions.Add("#DRIVERIGHT<300>%");
                    break;

                case 4:
                    listofActions.Add("#DRIVERIGHT<400>%");
                    break;

                case 5:
                    listofActions.Add("#DRIVERIGHT<500>%");
                    break;

                case 6:
                    listofActions.Add("#DRIVERIGHT<600>%");
                    break;

                case 7:
                    listofActions.Add("#DRIVERIGHT<700>%");
                    break;

                case 8:
                    listofActions.Add("#DRIVERIGHT<800>%");
                    break;

                case 9:
                    listofActions.Add("#DRIVERIGHT<900>%");
                    break;
            }
            return listofActions;
        }
    }
}

