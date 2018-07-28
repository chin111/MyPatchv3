using System;
using System.Collections.Generic;
using System.Text;

namespace MyPatchV3.UI.Models
{
    public class AuthenticationResponse
    {
        public string User_ID { get; set; }

        public string User_Type { get; set; }

        public string User_Msg { get; set; }

        public int IsActive { get; set; }
    }
}
