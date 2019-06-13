using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class SchetchikViewModel
    {
        public IEnumerable<AllCounter> AllCounters { get; set; }
        public PagingInfo PagingInfoCom { get; set; }
    }
}