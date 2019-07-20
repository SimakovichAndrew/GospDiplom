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
        public string CheckSort {get;set;}

        public List<AllCounter> SortCounter(string key)
        {
            switch (key)
            {
                case "2": return AllCounters.OrderBy(y => y.Date.DayOfYear).ToList(); 
                case "3": return AllCounters.OrderByDescending(y =>y.Span/* (.Tarif1End - y.Tarif1Start)*/).ToList();
                default: return  AllCounters.OrderBy(y => y.NomerKioska).ToList();
            }
        }
    }
}