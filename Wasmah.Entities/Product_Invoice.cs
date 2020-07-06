using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wasmah.Entities
{
    [Table("Product_Invoice")]
    public class Product_Invoice
    {
        #region Member Variables 
        public int Id { get; set; }
        #endregion

        #region Foreign Keys
        [ForeignKey("Product")]
        public int FK_ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Invoice")]
        public int FK_InvoiceId { get; set; }
        public Invoice Invoice{ get; set; }
        #endregion
    }
}
