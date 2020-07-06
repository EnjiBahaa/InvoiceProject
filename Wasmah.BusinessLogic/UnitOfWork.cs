using System;
using Wasmah.BusinessLogic.Manager;
using Wasmah.Context;

namespace Wasmah.BusinessLogic
{
    public class UnitOfWork
    {
        public DbContext Context { get; }
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public ProductManager ProductManager => new ProductManager(this);
        public InvoiceManager InvoiceManager => new InvoiceManager(this);
        public Product_InvoiceManager Product_InvoiceManager => new Product_InvoiceManager(this);

    }
}
