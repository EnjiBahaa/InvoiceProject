using System.Collections.Generic;

namespace Wasmah.WebAPI.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public float Total { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
