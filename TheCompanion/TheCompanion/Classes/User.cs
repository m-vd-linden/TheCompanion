using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCompanion.Classes
{
    public class User
    {
        public int UserID
        {
            get; private set;
        }

        public string Name
        {
            get; private set;
        }

        public User(int userID, string name)
        {
            UserID = userID;
            Name = name;
        }
    }
}
