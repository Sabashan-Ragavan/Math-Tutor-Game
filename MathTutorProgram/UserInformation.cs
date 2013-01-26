using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTutorProgram
{
    public class UserInformation
    {
        private static string username;
        private static int level;

        /*public UserInformation(string usrnme, int lvl)
        {
            username = usrnme;
            level = lvl; 
        }*/

        public static string User
        {
            get
            {
                return username; 
            }
            set
            {
                username = value; 
            }
        }

        public static int Level
        {
            get
            {
                return level;
            }
            set
            {
                if(value > level)
                    level = value; 
            }
        }

        public static void Clear()
        {
            username = "";
            level = 0; 
        }

    }
}
