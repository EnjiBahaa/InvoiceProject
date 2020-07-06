using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wasmah.Entities
{
    [Table("Invoice")]
    public class Invoice
    {
        #region Memeber Variable
        [Key]
        public int Id { get; set; }
        public float Total { get; set; }
        #endregion

        #region Entities List
        public IEnumerable<Product_Invoice> Product_Invoices{ get; set; }
        #endregion
    }
}
