using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundaWeb.Models
{
    public class FundaResponseModel
    {
        public List<FundaPropertyModel> Objects { get; set; } = new();
    }
}