using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAccountAPI.Models
{
    public class Purchase
    {
        #region [ Attributes ]

        public Int64 code { get; set; }

        public Client client { get; set; }

        public double price { get; set; }

        public Int64 quantity { get; set; }

        public DateTime purchaseDate { get; set; }

        public int status { get; set; }

        #endregion [ Attributes ]
    }
}
