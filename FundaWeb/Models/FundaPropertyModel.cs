using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundaWeb.Models
{
    public class FundaPropertyModel
    {
        public int MakelaarID { get; set; }
        public string MakelaarNaam { get; set; } = "";
        public bool IsVerkocht { get; set; }
    }
}