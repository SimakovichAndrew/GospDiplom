using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Entities
{
    public class Indication
    {
        [Required]
        public int IndicationId { get; set; }
        public DateTime Month { get; set; }
        public double Tarif1 { get; set; }
        public double Tarif2 { get; set; }
        public double TarifSumm { get; set; }

        [ForeignKey("Schetchik")]
        public int SchetchikId { get; set; }
        public Schetchik Schetchik { get; set; }

       
    }
}
