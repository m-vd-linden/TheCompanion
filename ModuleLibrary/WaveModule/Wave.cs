﻿using System;
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
        public List<string> Send(int skill)
        {
            switch (skill)
            {
                case 1:
                    listofActions.Add("#LEFTARMFORWARD<100>%");
                    break;

                case 2:
                    listofActions.Add("#LEFTARMFORWARD<200>%");
                    break;

                case 3:
                    listofActions.Add("#LEFTARMFORWARD<300>%");
                    break;

                case 4:
                    listofActions.Add("#LEFTARMFORWARD<400>%");
                    break;

                case 5:
                    listofActions.Add("#LEFTARMFORWARD<500>%");
                    break;

                case 6:
                    listofActions.Add("#LEFTARMFORWARD<600>%");
                    break;

                case 7:
                    listofActions.Add("#LEFTARMFORWARD<700>%");
                    break;

                case 8:
                    listofActions.Add("#LEFTARMFORWARD<800>%");
                    break;

                case 9:
                    listofActions.Add("#LEFTARMFORWARD<900>%");
                    break;
            }
            return listofActions;
        }
    }
}
