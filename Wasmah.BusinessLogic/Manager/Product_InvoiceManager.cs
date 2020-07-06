using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wasmah.Context;
using Wasmah.Entities;
using Wasmah.Repository;

namespace Wasmah.BusinessLogic.Manager
{
    public class Product_InvoiceManager : Repository<Product_Invoice, DbContext>
    {
        public Product_InvoiceManager(UnitOfWork unitOfWork) : base(unitOfWork.Context)
        {

        }

        public async override Task<Product_Invoice> GetByIdAsync(object id)
        {
            return (await GetAsync(a => a.Id == (int)id)).FirstOrDefault();
        }

        public async Task<List<Product_Invoice>> AddProductInvoice(int invoiceId, List<Product> products)
        {
            List<Product_Invoice> product_Invoices = new List<Product_Invoice>();
            foreach (var product in products)
            {
                Product_Invoice product_Invoice = new Product_Invoice();
                product_Invoice.FK_InvoiceId = invoiceId;
                product_Invoice.FK_ProductId = product.Id;
                product_Invoices.Add(product_Invoice);
                await CreateOnDbAsync(product_Invoice);
            }
            return product_Invoices;
        }
    }
}
