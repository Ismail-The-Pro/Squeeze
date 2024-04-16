using Squeeze.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bestilling
{
    [Key]
    public int BestillingId { get; set; }
    [ForeignKey("Kunde")]
    public int KundeId { get; set; }
    public DateTime Bestillingsdato { get; set; }
    public decimal TotalPris { get; set; }
    public string Status { get; set; }
    public virtual Kunde Kunde { get; set; }
    public virtual List<Bestillingsdetalj> Bestillingsdetaljer { get; set; }
}
