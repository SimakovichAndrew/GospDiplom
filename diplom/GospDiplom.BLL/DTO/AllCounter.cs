﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.BLL.DTO
{
    public class AllCounter
    {
        public int NomerCounter { get; set; }
        public string ModelCounter { get; set; }
        public string NomerKioska { get; set; }
        public double Tarif1 { get; set; }
        public double Tarif2 { get; set; }
        public bool TechUchet { get; set; }
        public bool TwoTarif { get; set; }
        public string Month { get; set; }
        public string OrgName { get; set; }
        public int Dogovor { get; set; }
    }
}
