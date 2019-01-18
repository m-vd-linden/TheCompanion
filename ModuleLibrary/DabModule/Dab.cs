using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabModule
{
    public class Dab
    {
        List<string> listofActions = new List<string>();
        public List<string> Send(int skill)
        {
            switch (skill)
            {
                case 1:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;

                case 2:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;

                case 3:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;

                case 4:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;

                case 5:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;

                case 6:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;

                case 7:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;

                case 8:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;

                case 9:
                    listofActions.Add("#RIGHTHANDBACKWARD<500>%");
                    listofActions.Add("#LEFTARMBACKWARD<100>%");
                    listofActions.Add("#LEFTHANDBACKWARD<1000>%");
                    break;
            }
            return listofActions;
        }
    }
}
