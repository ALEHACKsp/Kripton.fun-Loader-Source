using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime_Chat
{
    class UserInfo
    {
        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string fullname { get; set; }

        public string secretanswer { get; set; }

        public UserInfo(string username, string password, string email, string fullname, string secretanswer)
        {
            username = username;
            password = password;
            email = email;
            fullname = fullname;
            secretanswer = secretanswer;
        }
    }
}
