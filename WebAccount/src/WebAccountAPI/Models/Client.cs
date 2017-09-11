using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAccountAPI.Models
{
    public class Client
    {
        #region [ Attributes ]

        public Int64 code { get; set; }

        public string name { get; set; }

        public string cpf { get; set; }

        public DateTime birthyDay { get; set; }

        public int genre { get; set; }

        public string telephone { get; set; }

        public string telephone1 { get; set; }

        public string email { get; set; }

        public string cep { get; set; }

        public string address { get; set; }

        public int number { get; set; }

        public string neighboorood { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public Account account { get; set; }

        public int status { get; set; }

        #endregion [ Attributes ]
    }
}
