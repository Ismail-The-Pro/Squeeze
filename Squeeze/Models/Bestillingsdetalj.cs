using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



    public class Bestillingsdetalj
    {
        public int BestillingsdetaljId { get; set; }
        public int BestillingId { get; set; }
        public int LemonadeId { get; set; }
        public int Antall { get; set; } // Make sure this property exists
        public decimal Pris { get; set; }
        public string Tilpasninger { get; set; }
        public virtual Lemonade Lemonade { get; set; }
    }

