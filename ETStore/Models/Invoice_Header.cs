//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice_Header
    {
        public Invoice_Header()
        {
            this.Invoice_Detail = new HashSet<Invoice_Detail>();
        }
    
        public int InvoiceId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<System.DateTime> Purchase_Date { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ICollection<Invoice_Detail> Invoice_Detail { get; set; }
    }
}