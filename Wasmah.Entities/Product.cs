using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wasmah.Entities
{
    [Table("Product")]
    public class Product
    {
        #region Member Variables
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public int Count { get; set; }
        public string ProductNo { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        #endregion
    }
}
