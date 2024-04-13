namespace Squeeze.Models
{
    
    public class Rabatt
    {
        public int RabattId { get; set; }
        public int KundeId { get; set; }
        public double RabattProsent { get; set; }
        public DateTime GyldigTil { get; set; }
    }

}
