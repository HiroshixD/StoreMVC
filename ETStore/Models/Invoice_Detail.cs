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
    
    public partial class Invoice_Detail
    {
        public int InvoiceDetailId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> ProductQty { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> InvoiceId { get; set; }
    
        public virtual Invoice_Header Invoice_Header { get; set; }
        public virtual Product Product { get; set; }
    }
}
