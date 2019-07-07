using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;


namespace GospDiplom.WEB.Models
{
    public class TownListViewModel
    {
        public string Autor { get; set; }
        public IEnumerable<KioskDTO> GetKiosks { get; set; }
        public IEnumerable<SchetchikDTO> GetSchetchiks { get; set; }
        public PagingInfo PagingInfoCom { get; set; }
        public string CurrentTownName { get; set; }
        public int KioskId { get; set; }
        public string Content { get ; set ; }
    }
}