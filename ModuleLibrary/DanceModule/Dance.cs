﻿using System;
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

            List<string> listOfCommands = new List<string>();

            listOfCommands.Add("#Move_Left_Arm_Up%");
            listOfCommands.Add("#Move_Right_Arm_Up%");
            listOfCommands.Add("#Move_Left_Arm_Down%");
            listOfCommands.Add("#Move_Right_Arm_Down%");

            return listOfCommands;
        }
    }
}
