using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class SectionModel
    {
        public IEnumerable<SectionDTO> Sections { get; set; }
        public IEnumerable<KioskDTO> Kiosks { get; set; }
        public PagingInfo PagingInfoCom { get; set; }
    }
}