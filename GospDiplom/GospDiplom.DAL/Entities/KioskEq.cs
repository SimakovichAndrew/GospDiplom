﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.DAL.Entities
{
    public class KioskEq
    {
        public int KioskEqId { get; set;}
        public int EqId { get; set; }
        public int KioskId { get; set; }
        public int Quantity { get; set; }

    }
}
