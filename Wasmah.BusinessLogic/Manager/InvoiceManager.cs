using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wasmah.Context;
using Wasmah.Entities;
using Wasmah.Repository;

namespace Wasmah.BusinessLogic.Manager
{
    public class InvoiceManager : Repository<Invoice, DbContext>
    {

        private readonly UnitOfWork _unitOfWork;
        public InvoiceManager(UnitOfWork unitOfWork) : base(unitOfWork.Context)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<Invoice> GetByIdAsync(object id)
        {
            return (await GetAsync(a => a.Id == (int)id)).FirstOrDefault();
        }

        public async Task<IQueryable<Invoice>> GetAllAsync()
        {
            return (await GetAsync());
        }

        //public async Task<Invoice> AddAsync(List<Product> products)
        //{
            
        //    //var invoiceResult = CalculateInvoice(products);

        //}

        public async Task<Invoice> AddInvoice(List<Product> products)
        {
            Invoice invoice = new Invoice();
            invoice.Total = CalculateInvoice(products);    
            var invoiceAdded =await CreateAsync(invoice);
            await SaveChangesAsync();
           
            await _unitOfWork.Product_InvoiceManager.AddProductInvoice(invoiceAdded.Id, products);
            return invoiceAdded;
        }

        public float CalculateInvoice(List<Product> products)
        {
            float result = 0;
            foreach (var product in products)
            {
                result += (product.Count) * (product.UnitPrice);
            }
            return result;
        }
    }
}
