using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAccountAPI.Models
{
    public class Account
    {
        #region [ Attributes ]

        public Int64 code { get; set; }

        public string account { get; set; }

        public string agency { get; set; }

        public string digit { get; set; }

        public string codeBank { get; set; }

        public int status { get; set; }

        #endregion [ Attributes ]
    }
}
