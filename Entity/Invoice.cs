using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFluentDesign.Entity
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public double TotalPrice { get; set;}
        public int TotalAmount { get; set;}
    }
}
