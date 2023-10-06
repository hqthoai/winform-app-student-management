using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class Global
    {
        private static int GlobalUserID;
        public static int GlobalUserID1 { get => GlobalUserID; set => GlobalUserID = value; }

        public static void SetGlobalUserId(int userID)
        {
            GlobalUserID1 = userID;
        }
    }
}
