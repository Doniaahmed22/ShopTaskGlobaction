using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFluentDesign.Entity
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int CustomerID { get; set; }
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
