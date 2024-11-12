using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FinalCProject.DTH
{
    internal static class GetInfor
    {
        private static string email;
        private static string movieid;
        private static string username;
        public static string Email
        {
            get { return email; }
            set { email = value; }
        }

        public static string Movieid
        {
            get { return movieid; }
            set { movieid = value; }
        }

        public static string Username
        {
            get { return username; }
            set {  username = value; }
        }
    }
}
