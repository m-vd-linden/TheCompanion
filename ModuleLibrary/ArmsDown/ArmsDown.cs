using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmsDown
{
    public class ArmsDown
    {
        List<string> listofActions = new List<string>();
        public List<string> Send(int skill)
        {
            switch (skill)
            {
                case 1:
                    listofActions.Add("#RPS%");
                    break;

                case 2:
                    listofActions.Add("#RPS%");
                    break;

                case 3:
                    listofActions.Add("#RPS%");
                    break;

                case 4:
                    listofActions.Add("#RPS%");
                    break;

                case 5:
                    listofActions.Add("#RPS%");
                    break;

                case 6:
                    listofActions.Add("#RPS%");
                    break;

                case 7:
                    listofActions.Add("#RPS%");
                    break;

                case 8:
                    listofActions.Add("#RPS%");
                    break;

                case 9:
                    listofActions.Add("#RPS%");
                    break;
            }

            return listofActions;
        }
    }
}
